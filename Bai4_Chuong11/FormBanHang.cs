using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QLTraSuaApp.Models;
using QLTraSuaApp.Services;
using Log = Serilog.Log;

namespace QLTraSuaApp
{
    public partial class FormBanHang : Form
    {
        private readonly VietQrService _qrService = new();
        private readonly List<CartItemDto> _cart = new();
        private readonly string _connectionString = string.Empty;
        private readonly IConfiguration _config;

        public FormBanHang()
        {
            InitializeComponent();

            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _connectionString = _config.GetConnectionString("DefaultConnection")!;

            // Đăng ký sự kiện Load của Form
            this.Load += FormBanHang_Load;
        }

        private async void FormBanHang_Load(object? sender, EventArgs e)
        {
            InitSampleCart();
            await LoadCategoryComboAsync();
        }

        private async Task LoadCategoryComboAsync()
        {
            try
            {
                using var db = new QLTraSuaContext(_connectionString);
                var categories = await db.DanhMucMons.AsNoTracking().ToListAsync();

                if (categories == null || categories.Count == 0)
                {
                    MessageBox.Show("Bảng DanhMucMon chưa có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tắt tạm sự kiện để tránh kích hoạt sự kiện khi đang gán DataSource
                cboDanhMuc.SelectedIndexChanged -= cboDanhMuc_SelectedIndexChanged;
                cboDanhMuc.DisplayMember = "TenDM";
                cboDanhMuc.ValueMember = "MaDM";
                cboDanhMuc.DataSource = categories;
                cboDanhMuc.SelectedIndexChanged += cboDanhMuc_SelectedIndexChanged;

                // LẤY TRỰC TIẾP MaDM CỦA PHẦN TỬ ĐẦU TIÊN (Khắc phục triệt để lỗi ListBox bị trống)
                int firstMaDM = categories[0].MaDM;
                await LoadMonUongByDanhMucAsync(firstMaDM);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi nạp danh mục món uống");
                MessageBox.Show("Lỗi kết nối CSDL QL_TraSua!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadMonUongByDanhMucAsync(int maDM)
        {
            try
            {
                using var db = new QLTraSuaContext(_connectionString);
                var list = await db.MonUongs
                    .AsNoTracking()
                    .Where(m => m.MaDM == maDM && m.DangBan)
                    .ToListAsync();

                lstMonUong.DataSource = null;
                lstMonUong.DisplayMember = "DisplayText";
                lstMonUong.ValueMember = "MaMon";
                lstMonUong.DataSource = list;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi nạp món uống theo MaDM = {MaDM}", maDM);
            }
        }

        private async void cboDanhMuc_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Bắt linh hoạt cả int lẫn đối tượng DanhMucMon
            if (cboDanhMuc.SelectedValue is int maDM)
            {
                await LoadMonUongByDanhMucAsync(maDM);
            }
            else if (cboDanhMuc.SelectedItem is DanhMucMon dm)
            {
                await LoadMonUongByDanhMucAsync(dm.MaDM);
            }
        }

        private void InitSampleCart()
        {
            _cart.Clear();
            _cart.Add(new CartItemDto { MaMon = 1, TenMon = "Trà sữa trân châu", SoLy = 2, DonGia = 35000 });
            _cart.Add(new CartItemDto { MaMon = 2, TenMon = "Trà sữa matcha", SoLy = 1, DonGia = 40000 });
            _cart.Add(new CartItemDto { MaMon = 8, TenMon = "Trân châu trắng", SoLy = 2, DonGia = 5000 });

            UpdateCartGridAndTotal();
            lblSoTienVal.Text = "120.000 đ";
            lblNoiDungVal.Text = "TRASUA HD1024";
        }

        private void btnThemVaoDon_Click(object sender, EventArgs e)
        {
            if (lstMonUong.SelectedItem is not MonUong selectedMon) return;

            int quantity = (int)nudSoLy.Value;
            var existing = _cart.FirstOrDefault(x => x.MaMon == selectedMon.MaMon);

            if (existing != null)
            {
                existing.SoLy += quantity;
            }
            else
            {
                _cart.Add(new CartItemDto
                {
                    MaMon = selectedMon.MaMon,
                    TenMon = selectedMon.TenMon,
                    SoLy = quantity,
                    DonGia = selectedMon.GiaBan
                });
            }

            UpdateCartGridAndTotal();
        }

        private void UpdateCartGridAndTotal()
        {
            dgvGioHang.DataSource = null;
            dgvGioHang.DataSource = _cart;

            if (dgvGioHang.Columns["MaMon"] != null) dgvGioHang.Columns["MaMon"].Visible = false;
            if (dgvGioHang.Columns["TenMon"] != null) dgvGioHang.Columns["TenMon"].HeaderText = "Tên món";
            if (dgvGioHang.Columns["SoLy"] != null) dgvGioHang.Columns["SoLy"].HeaderText = "SL";
            if (dgvGioHang.Columns["DonGia"] != null)
            {
                dgvGioHang.Columns["DonGia"].HeaderText = "Đơn giá";
                dgvGioHang.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            }
            if (dgvGioHang.Columns["ThanhTien"] != null)
            {
                dgvGioHang.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dgvGioHang.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            }

            decimal total = _cart.Sum(x => x.ThanhTien);
            lblTongTien.Text = $"Tổng tiền: {total:N0} đ";
            lblSoTienVal.Text = $"{total:N0} đ";
        }

        private void btnXoaDong_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow?.DataBoundItem is CartItemDto selectedItem)
            {
                _cart.Remove(selectedItem);
                UpdateCartGridAndTotal();
            }
        }

        private async void btnChuyenKhoan_Click(object sender, EventArgs e)
        {
            decimal total = _cart.Sum(x => x.ThanhTien);
            if (total <= 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 món vào đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var paySection = _config.GetSection("Payment");
            string bankId = paySection["BankId"]!;
            string accountNo = paySection["AccountNo"]!;
            string accountName = paySection["AccountName"]!;
            string template = paySection["Template"]!;

            string memo = $"TRASUA HD{DateTime.Now:HHmmss}";

            var qrImage = await _qrService.GenerateQrCodeAsync(bankId, accountNo, template, total, memo, accountName);

            if (qrImage != null)
            {
                picQR.Image = qrImage;
                lblSoTienVal.Text = $"{total:N0} đ";
                lblNoiDungVal.Text = memo;
            }
            else
            {
                MessageBox.Show($"Không thể kết nối VietQR! Thông tin chuyển khoản:\nSTK: {accountNo}\nChủ TK: {accountName}\nSố tiền: {total:N0} đ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblSoTienVal.Text = $"{total:N0} đ";
                lblNoiDungVal.Text = memo;
            }
        }

        private async void btnDaNhanTien_Click(object sender, EventArgs e)
        {
            await SaveOrderToDatabaseAsync("Chuyển khoản");
        }

        private async void btnTienMat_Click(object sender, EventArgs e)
        {
            await SaveOrderToDatabaseAsync("Tiền mặt");
        }

        private async Task SaveOrderToDatabaseAsync(string hinhThucTT)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Đơn hàng đang trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new QLTraSuaContext(_connectionString);
                using var transaction = await db.Database.BeginTransactionAsync();

                var hoaDon = new HoaDon
                {
                    NgayLap = DateTime.Now,
                    TongTien = _cart.Sum(x => x.ThanhTien),
                    HinhThucTT = hinhThucTT,
                    DaThanhToan = true
                };

                db.HoaDons.Add(hoaDon);
                await db.SaveChangesAsync();

                foreach (var item in _cart)
                {
                    db.ChiTietHoaDons.Add(new ChiTietHoaDon
                    {
                        MaHD = hoaDon.MaHD,
                        MaMon = item.MaMon,
                        SoLy = item.SoLy,
                        DonGia = item.DonGia
                    });
                }

                await db.SaveChangesAsync();
                await transaction.CommitAsync();

                MessageBox.Show($"Đã thanh toán thành công Hóa đơn #{hoaDon.MaHD} ({hinhThucTT})!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _cart.Clear();
                UpdateCartGridAndTotal();
                picQR.Image = null;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi lưu hóa đơn giao dịch");
                MessageBox.Show("Không thể hoàn tất thanh toán!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class CartItemDto
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; } = string.Empty;
        public int SoLy { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLy * DonGia;
    }
}