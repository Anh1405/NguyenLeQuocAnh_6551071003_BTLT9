using Bai1_Chuong11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Bai1_Chuong11.Models;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLChiTieuApp
{
    public partial class FormChiTieu : Form
    {
        private readonly string _connectionString = string.Empty;
        private int _selectedMaCT = 0;

        public FormChiTieu()
        {
            InitializeComponent();

            // Khởi tạo Cấu hình Strongly-Typed từ appsettings.json
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile("appsettings.Development.json", optional: true);

            IConfiguration configuration = builder.Build();
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;

            // Khởi tạo Serilog ghi file theo ngày vào thư mục Logs
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(Path.Combine("Logs", "log-.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            dtpTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpDenNgay.Value = DateTime.Today;
            cboLoaiChi.SelectedIndex = 0;
            cboLocLoaiChi.SelectedIndex = 0;

            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                using var db = new QLChiTieuContext(_connectionString);
                var query = db.ChiTieus.AsQueryable();

                if (!string.IsNullOrWhiteSpace(txtTimNoiDung.Text))
                    query = query.Where(x => x.NoiDung.Contains(txtTimNoiDung.Text.Trim()));

                if (cboLocLoaiChi.SelectedIndex > 0)
                    query = query.Where(x => x.LoaiChi == cboLocLoaiChi.SelectedItem!.ToString());

                query = query.Where(x => x.NgayChi >= dtpTuNgay.Value.Date && x.NgayChi <= dtpDenNgay.Value.Date);

                var list = await query.OrderByDescending(x => x.NgayChi).ToListAsync();
                dgvChiTieu.DataSource = list;

                // Format Datagridview Columns
                if (dgvChiTieu.Columns["MaCT"] != null) dgvChiTieu.Columns["MaCT"].HeaderText = "Mã";
                if (dgvChiTieu.Columns["NgayChi"] != null) dgvChiTieu.Columns["NgayChi"].HeaderText = "Ngày chi";
                if (dgvChiTieu.Columns["NoiDung"] != null) dgvChiTieu.Columns["NoiDung"].HeaderText = "Nội dung";
                if (dgvChiTieu.Columns["LoaiChi"] != null) dgvChiTieu.Columns["LoaiChi"].HeaderText = "Loại chi";
                if (dgvChiTieu.Columns["SoTien"] != null)
                {
                    dgvChiTieu.Columns["SoTien"].HeaderText = "Số tiền";
                    dgvChiTieu.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                }
                if (dgvChiTieu.Columns["GhiChu"] != null) dgvChiTieu.Columns["GhiChu"].HeaderText = "Ghi chú";

                // Tính tổng tiền đang hiển thị
                decimal tongChi = list.Sum(x => x.SoTien);
                lblTongChi.Text = $"Tổng chi: {tongChi:N0} đ";
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi truy vấn CSDL QL_ChiTieu");
                MessageBox.Show("Có lỗi xảy ra khi truy vấn CSDL, chi tiết đã được lưu log!", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                MessageBox.Show("Nội dung không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return false;
            }
            if (nudSoTien.Value <= 0)
            {
                MessageBox.Show("Số tiền phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudSoTien.Focus();
                return false;
            }
            if (dtpNgayChi.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày chi không được lớn hơn ngày hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                using var db = new QLChiTieuContext(_connectionString);
                var item = new ChiTieu
                {
                    NgayChi = dtpNgayChi.Value.Date,
                    NoiDung = txtNoiDung.Text.Trim(),
                    LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác",
                    SoTien = nudSoTien.Value,
                    GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim()
                };

                db.ChiTieus.Add(item);
                await db.SaveChangesAsync();

                Log.Information("Thêm khoản chi mới thành công: MaCT = {MaCT}, SoTien = {SoTien}", item.MaCT, item.SoTien);
                ClearForm();
                LoadData();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi thêm mới khoản chi");
                MessageBox.Show("Không thể thêm khoản chi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaCT == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần sửa từ bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput()) return;

            try
            {
                using var db = new QLChiTieuContext(_connectionString);
                var item = await db.ChiTieus.FindAsync(_selectedMaCT);
                if (item != null)
                {
                    item.NgayChi = dtpNgayChi.Value.Date;
                    item.NoiDung = txtNoiDung.Text.Trim();
                    item.LoaiChi = cboLoaiChi.SelectedItem?.ToString() ?? "Khác";
                    item.SoTien = nudSoTien.Value;
                    item.GhiChu = string.IsNullOrWhiteSpace(txtGhiChu.Text) ? null : txtGhiChu.Text.Trim();

                    await db.SaveChangesAsync();
                    Log.Information("Cập nhật khoản chi thành công: MaCT = {MaCT}", _selectedMaCT);
                    ClearForm();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi sửa MaCT = {MaCT}", _selectedMaCT);
                MessageBox.Show("Không thể cập nhật dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaCT == 0)
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa khoản chi MaCT = {_selectedMaCT}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                using var db = new QLChiTieuContext(_connectionString);
                var item = await db.ChiTieus.FindAsync(_selectedMaCT);
                if (item != null)
                {
                    db.ChiTieus.Remove(item);
                    await db.SaveChangesAsync();
                    Log.Information("Xóa khoản chi thành công: MaCT = {MaCT}", _selectedMaCT);
                    ClearForm();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi khi xóa MaCT = {MaCT}", _selectedMaCT);
                MessageBox.Show("Không thể xóa khoản chi này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiTieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvChiTieu.Rows[e.RowIndex];
                _selectedMaCT = Convert.ToInt32(row.Cells["MaCT"].Value);
                dtpNgayChi.Value = Convert.ToDateTime(row.Cells["NgayChi"].Value);
                txtNoiDung.Text = row.Cells["NoiDung"].Value?.ToString();
                cboLoaiChi.SelectedItem = row.Cells["LoaiChi"].Value?.ToString();
                nudSoTien.Value = Convert.ToDecimal(row.Cells["SoTien"].Value);
                txtGhiChu.Text = row.Cells["GhiChu"].Value?.ToString() ?? string.Empty;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadData();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearForm()
        {
            _selectedMaCT = 0;
            txtNoiDung.Clear();
            txtGhiChu.Clear();
            nudSoTien.Value = 0;
            dtpNgayChi.Value = DateTime.Today;
            if (cboLoaiChi.Items.Count > 0) cboLoaiChi.SelectedIndex = 0;
        }
    }
}