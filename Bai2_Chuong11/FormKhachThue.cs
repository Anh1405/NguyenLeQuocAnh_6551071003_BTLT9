using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic.Logging;
using QLNhaTroApp.Models;
using QLNhaTroApp.Services;
using Serilog;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log = Serilog.Log;
namespace QLNhaTroApp
{
    public partial class FormKhachThue : Form
    {
        private readonly AddressApiService _apiService = new();
        private readonly string _connectionString = string.Empty;
        private int _selectedMaKhach = 0;

        public FormKhachThue()
        {
            InitializeComponent();

            // Khởi tạo đọc Cấu hình
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _connectionString = config.GetConnectionString("DefaultConnection")!;

            // Khởi tạo Serilog ghi log hệ thống ra thư mục Logs
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine("Logs", "log-.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            RegisterGlobalExceptionHandlers();
            LoadDataAsync();
        }

        // Bắt lỗi toàn cục giúp app "không chết" bất ngờ (Task 7)
        private void RegisterGlobalExceptionHandlers()
        {
            // XÓA HOẶC COMMENT DÒNG NÀY (vì đã có trong Program.cs):
            // Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Chỉ giữ lại 2 dòng đăng ký sự kiện này:
            Application.ThreadException += (s, e) => HandleGlobalException(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => HandleGlobalException(e.ExceptionObject as Exception);
        }

        private void HandleGlobalException(Exception? ex)
        {
            if (ex != null) Log.Error(ex, "Lỗi chưa xử lý trong hệ thống");
            MessageBox.Show("Đã xảy ra lỗi, thông tin đã được ghi lại.", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void LoadDataAsync()
        {
            await LoadPhongComboAsync();
            await RefreshGridAsync();
            await LoadProvincesAsync();
        }

        // Tích hợp API Tỉnh / Phường Xã bất đồng bộ (Task 3)
        private async Task LoadProvincesAsync()
        {
            try
            {
                lblStatus.Text = "Đang tải danh sách Tỉnh/Thành...";
                cboTinhThanh.Enabled = false;

                var provinces = await _apiService.GetProvincesAsync();

                cboTinhThanh.DataSource = provinces;
                cboTinhThanh.DisplayMember = "Name";
                cboTinhThanh.ValueMember = "Code";
                cboTinhThanh.Enabled = true;

                lblStatus.Text = $"Đã tải {provinces.Count} tỉnh/thành từ provinces.open-api.vn";
            }
            catch (Exception ex) when (ex is HttpRequestException || ex is TaskCanceledException)
            {
                Log.Warning(ex, "Mất mạng hoặc API không phản hồi");
                MessageBox.Show("Không tải được danh sách địa chỉ, vui lòng kiểm tra mạng.", "Cảnh báo kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Chịu lỗi mạng: Cho phép gõ tay Phường/Xã (Task 8)
                cboPhuongXa.Visible = false;
                txtPhuongXaManual.Visible = true;
                lblStatus.Text = "Chế độ ngoại tuyến: Cho phép nhập tay Phường/Xã";
            }
        }

        private async void cboTinhThanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTinhThanh.SelectedValue is int provinceCode && cboPhuongXa.Visible)
            {
                try
                {
                    cboPhuongXa.Enabled = false;
                    var wards = await _apiService.GetWardsAsync(provinceCode);
                    cboPhuongXa.DataSource = wards;
                    cboPhuongXa.DisplayMember = "Name";
                    cboPhuongXa.ValueMember = "Code";
                    cboPhuongXa.Enabled = true;
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Lỗi khi nạp danh sách Phường/Xã của tỉnh {Code}", provinceCode);
                }
            }
        }

        private async Task LoadPhongComboAsync()
        {
            using var db = new QLNhaTroContext(_connectionString);
            var phongs = await db.PhongTros.ToListAsync();

            cboPhong.DataSource = phongs;
            cboPhong.DisplayMember = "DisplayText";
            cboPhong.ValueMember = "MaPhong";

            var listLoc = phongs.ToList();
            listLoc.Insert(0, new PhongTro { MaPhong = 0, TenPhong = "Tất cả" });
            cboLocPhong.DataSource = listLoc;
            cboLocPhong.DisplayMember = "TenPhong";
            cboLocPhong.ValueMember = "MaPhong";
        }

        // Tải danh sách khách thuê hiển thị kết quả JOIN (Task 5)
        private async Task RefreshGridAsync()
        {
            try
            {
                using var db = new QLNhaTroContext(_connectionString);
                var query = db.KhachThues.Include(k => k.PhongTro).AsQueryable();

                if (!string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    string kw = txtTimKiem.Text.Trim();
                    query = query.Where(k => k.HoTen.Contains(kw) || k.SoDienThoai.Contains(kw));
                }

                if (cboLocPhong.SelectedValue is int maPhong && maPhong > 0)
                {
                    query = query.Where(k => k.MaPhong == maPhong);
                }

                var list = await query.Select(k => new
                {
                    k.MaKhach,
                    k.HoTen,
                    SĐT = k.SoDienThoai,
                    Phòng = k.PhongTro.TenPhong,
                    GiáThuê = k.PhongTro.GiaThue,
                    QuêQuán = $"{k.TenPhuongXa} - {k.TenTinh}",
                    TạmTrú = k.DaDangKyTamTru
                }).ToListAsync();

                dgvKhachThue.DataSource = list;

                // Định dạng giao diện hiển thị bảng
                if (dgvKhachThue.Columns["MaKhach"] != null) dgvKhachThue.Columns["MaKhach"].Visible = false;
                if (dgvKhachThue.Columns["HoTen"] != null) dgvKhachThue.Columns["HoTen"].HeaderText = "Họ tên";
                if (dgvKhachThue.Columns["GiáThuê"] != null)
                {
                    dgvKhachThue.Columns["GiáThuê"].HeaderText = "Giá thuê";
                    dgvKhachThue.Columns["GiáThuê"].DefaultCellStyle.Format = "N0";
                }
                if (dgvKhachThue.Columns["QuêQuán"] != null) dgvKhachThue.Columns["QuêQuán"].HeaderText = "Quê quán";
                if (dgvKhachThue.Columns["TạmTrú"] != null) dgvKhachThue.Columns["TạmTrú"].HeaderText = "Tạm trú";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi truy vấn CSDL danh sách khách thuê");
            }
        }

        // CRUD nhiều bảng (Task 4)
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng điền họ tên và số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new QLNhaTroContext(_connectionString);
                int maPhong = (int)cboPhong.SelectedValue!;
                var phong = await db.PhongTros.FindAsync(maPhong);

                var khach = new KhachThue
                {
                    HoTen = txtHoTen.Text.Trim(),
                    GioiTinh = rdbNam.Checked ? "Nam" : "Nữ",
                    NgaySinh = dtpNgaySinh.Value.Date,
                    SoDienThoai = txtSoDienThoai.Text.Trim(),
                    MaPhong = maPhong,
                    MaTinh = cboTinhThanh.SelectedValue is int tCode ? tCode : 0,
                    TenTinh = cboTinhThanh.Text,
                    MaPhuongXa = cboPhuongXa.SelectedValue is int pCode ? pCode : 0,
                    TenPhuongXa = txtPhuongXaManual.Visible ? txtPhuongXaManual.Text.Trim() : cboPhuongXa.Text,
                    DaDangKyTamTru = chkTamTru.Checked
                };

                db.KhachThues.Add(khach);

                // Quy tắc nghiệp vụ: Khi thêm khách vào phòng thì phòng chuyển "Đang thuê"
                if (phong != null) phong.TinhTrang = "Đang thuê";

                await db.SaveChangesAsync();
                Log.Information("Đã thêm khách thuê thành công: {HoTen}, Phòng: {Phong}", khach.HoTen, phong?.TenPhong);

                await RefreshGridAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm khách thuê");
                MessageBox.Show("Không thể thêm khách thuê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaKhach == 0)
            {
                MessageBox.Show("Vui lòng chọn khách thuê từ bảng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using var db = new QLNhaTroContext(_connectionString);
                var khach = await db.KhachThues.FindAsync(_selectedMaKhach);
                if (khach != null)
                {
                    khach.HoTen = txtHoTen.Text.Trim();
                    khach.GioiTinh = rdbNam.Checked ? "Nam" : "Nữ";
                    khach.NgaySinh = dtpNgaySinh.Value.Date;
                    khach.SoDienThoai = txtSoDienThoai.Text.Trim();
                    khach.MaPhong = (int)cboPhong.SelectedValue!;
                    khach.DaDangKyTamTru = chkTamTru.Checked;

                    await db.SaveChangesAsync();
                    Log.Information("Cập nhật thông tin khách thuê MaKhach = {MaKhach}", _selectedMaKhach);

                    await RefreshGridAsync();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi sửa khách thuê MaKhach = {MaKhach}", _selectedMaKhach);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaKhach == 0) return;

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa khách thuê này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using var db = new QLNhaTroContext(_connectionString);
                var khach = await db.KhachThues.FindAsync(_selectedMaKhach);
                if (khach != null)
                {
                    int maPhong = khach.MaPhong;
                    db.KhachThues.Remove(khach);
                    await db.SaveChangesAsync();

                    // Quy tắc nghiệp vụ: Xóa người cuối cùng của phòng thì phòng trở lại "Trống"
                    int remainingCount = await db.KhachThues.CountAsync(k => k.MaPhong == maPhong);
                    if (remainingCount == 0)
                    {
                        var phong = await db.PhongTros.FindAsync(maPhong);
                        if (phong != null) phong.TinhTrang = "Trống";
                        await db.SaveChangesAsync();
                    }

                    Log.Information("Xóa khách thuê MaKhach = {MaKhach}", _selectedMaKhach);
                    await RefreshGridAsync();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa khách thuê MaKhach = {MaKhach}", _selectedMaKhach);
            }
        }

        private void dgvKhachThue_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvKhachThue.Rows[e.RowIndex];
                _selectedMaKhach = Convert.ToInt32(row.Cells["MaKhach"].Value);
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtSoDienThoai.Text = row.Cells["SĐT"].Value?.ToString();
                chkTamTru.Checked = Convert.ToBoolean(row.Cells["TạmTrú"].Value);
            }
        }

        private async void btnTim_Click(object sender, EventArgs e) => await RefreshGridAsync();

        private void btnGayLoiThu_Click(object sender, EventArgs e) => throw new InvalidOperationException("Thử nghiệm văng lỗi hệ thống ngẫu nhiên!");

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            _selectedMaKhach = 0;
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            rdbNam.Checked = true;
            chkTamTru.Checked = false;
            dtpNgaySinh.Value = DateTime.Today;
        }
    }
}