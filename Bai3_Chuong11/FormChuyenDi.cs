using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QLDaNgoaiApp.Models;
using QLDaNgoaiApp.Services;
using Log = Serilog.Log;

namespace QLDaNgoaiApp
{
    public partial class FormChuyenDi : Form
    {
        private readonly WeatherService _weatherService = new();
        private readonly string _connectionString = string.Empty;
        private int _selectedMaChuyen = 0;

        public FormChuyenDi()
        {
            InitializeComponent();

            // Đọc cấu hình chuỗi kết nối
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            _connectionString = config.GetConnectionString("DefaultConnection")!;

            // Vẽ icon Đám mây / Mưa bằng Graphics
            picCloudIcon.Image = DrawCloudIcon();

            // Nạp ngôn ngữ đã lưu từ %LocalAppData%
            var settings = UserSettingsManager.Load();
            cboNgonNgu.SelectedIndex = settings.Language == "en-US" ? 1 : 0;
            ApplyCulture(settings.Language);

            cboPhuongTien.SelectedIndex = 0;
            txtNganSach.Text = "3.500.000";
            dtpNgayDi.Value = new DateTime(2026, 10, 25);
        }

        private async void LoadDataAsync()
        {
            try
            {
                using var db = new QLDaNgoaiContext(_connectionString);
                var query = db.ChuyenDis.AsQueryable();

                if (!string.IsNullOrWhiteSpace(txtTimDiaDiem.Text))
                {
                    string kw = txtTimDiaDiem.Text.Trim();
                    query = query.Where(x => x.DiaDiem.Contains(kw) || x.TenChuyen.Contains(kw));
                }

                if (chkChuaHoanThanh.Checked)
                {
                    query = query.Where(x => !x.DaHoanThanh);
                }

                var list = await query.ToListAsync();
                dgvChuyenDi.DataSource = list;

                // Định dạng hiển thị DataGridView
                if (dgvChuyenDi.Columns["MaChuyen"] != null) dgvChuyenDi.Columns["MaChuyen"].HeaderText = "Mã";
                if (dgvChuyenDi.Columns["TenChuyen"] != null) dgvChuyenDi.Columns["TenChuyen"].HeaderText = "Tên chuyến";
                if (dgvChuyenDi.Columns["DiaDiem"] != null) dgvChuyenDi.Columns["DiaDiem"].HeaderText = "Địa điểm";
                if (dgvChuyenDi.Columns["NgayDi"] != null) dgvChuyenDi.Columns["NgayDi"].HeaderText = "Ngày đi";
                if (dgvChuyenDi.Columns["SoNguoi"] != null) dgvChuyenDi.Columns["SoNguoi"].HeaderText = "Số người";
                if (dgvChuyenDi.Columns["NganSach"] != null)
                {
                    dgvChuyenDi.Columns["NganSach"].HeaderText = "Ngân sách";
                    dgvChuyenDi.Columns["NganSach"].DefaultCellStyle.Format = "N0";
                }
                if (dgvChuyenDi.Columns["PhuongTien"] != null) dgvChuyenDi.Columns["PhuongTien"].HeaderText = "Phương tiện";
                if (dgvChuyenDi.Columns["DaHoanThanh"] != null) dgvChuyenDi.Columns["DaHoanThanh"].HeaderText = "Hoàn thành";
                if (dgvChuyenDi.Columns["GhiChu"] != null) dgvChuyenDi.Columns["GhiChu"].Visible = false;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi truy vấn CSDL QL_DaNgoai");
            }
        }

        // Tích hợp API Thời tiết Open-Meteo (Task 5, 6, 7)
        private async void btnXemThoiTiet_Click(object sender, EventArgs e)
        {
            string diaDiem = txtDiaDiem.Text.Trim();
            DateTime ngayDi = dtpNgayDi.Value.Date;

            if (string.IsNullOrWhiteSpace(diaDiem))
            {
                MessageBox.Show("Vui lòng nhập địa điểm cần xem thời tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnXemThoiTiet.Enabled = false;
            pbLoading.Style = ProgressBarStyle.Marquee;
            pbLoading.Visible = true;

            bool isEn = cboNgonNgu.SelectedIndex == 1;

            try
            {
                var forecast = await _weatherService.GetWeatherForecastAsync(diaDiem, ngayDi, isEn);

                if (forecast == null)
                {
                    string msg = isEn
                        ? "No weather forecast data found. Try typing location without accents (e.g., 'Da Lat')!"
                        : "Không tìm thấy địa danh hoặc ngày đi vượt quá 16 ngày. Gợi ý thử gõ tên không dấu như 'Da Lat'!";
                    MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                lblThoiTietTitle.Text = isEn
                    ? $"Weather forecast for {ngayDi:dd/MM/yyyy} - {diaDiem}"
                    : $"Dự báo thời tiết ngày {ngayDi:dd/MM/yyyy} - {diaDiem}";

                lblMoTaThoiTiet.Text = forecast.Description;
                lblNhietDo.Text = isEn ? $"Temperature: {forecast.TempMin}°C - {forecast.TempMax}°C" : $"Nhiệt độ: {forecast.TempMin}°C - {forecast.TempMax}°C";
                lblKhaNangMua.Text = isEn ? $"Rain probability: {forecast.RainProbability}%" : $"Khả năng mưa: {forecast.RainProbability}%";

                // Quy tắc: Nếu xác suất mưa > 60% thì tô nền cam và hiện cảnh báo (Task 6)
                if (forecast.RainProbability > 60)
                {
                    pnlCanhBao.Visible = true;
                    pnlCanhBao.BackColor = Color.FromArgb(254, 215, 170);
                    lblCanhBaoText.Text = isEn ? "Should bring a raincoat or consider rescheduling" : "Nên mang áo mưa hoặc cân nhắc dời lịch";
                }
                else
                {
                    pnlCanhBao.Visible = true;
                    pnlCanhBao.BackColor = Color.FromArgb(187, 247, 208); // Nền xanh nhạt
                    lblCanhBaoText.Text = isEn ? "Good weather for traveling!" : "Thời tiết thuận lợi cho chuyến đi!";
                }

                Log.Information("Đã lấy dự báo thời tiết thành công cho {DiaDiem} ngày {NgayDi}", diaDiem, ngayDi);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi kết nối API thời tiết");
                string errorMsg = isEn ? "Failed to load weather data. Please check network!" : "Không thể tải dữ liệu thời tiết. Vui lòng kiểm tra mạng!";
                MessageBox.Show(errorMsg, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnXemThoiTiet.Enabled = true;
                pbLoading.Visible = false;
            }
        }

        // Đa ngôn ngữ chuyển đổi tức thì (Task 8)
        private void cboNgonNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cultureCode = cboNgonNgu.SelectedIndex == 1 ? "en-US" : "vi-VN";
            UserSettingsManager.Save(new UserSettings { Language = cultureCode });
            ApplyCulture(cultureCode);
        }

        private void ApplyCulture(string cultureCode)
        {
            CultureInfo culture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            bool isEn = cultureCode == "en-US";

            this.Text = isEn ? "Weekend Picnic Planner" : "Kế hoạch dã ngoại cuối tuần";
            lblHeaderTitle.Text = isEn ? "Weekend Picnic Planner" : "Kế hoạch dã ngoại cuối tuần";
            lblNgonNgu.Text = isEn ? "Language" : "Ngôn ngữ";
            grpThongTin.Text = isEn ? "Trip Information" : "Thông tin chuyến đi";
            lblTenChuyen.Text = isEn ? "Trip Name" : "Tên chuyến";
            lblDiaDiem.Text = isEn ? "Location" : "Địa điểm";
            lblNgayDi.Text = isEn ? "Departure Date" : "Ngày đi";
            lblSoNguoi.Text = isEn ? "People" : "Số người";
            lblNganSach.Text = isEn ? "Budget" : "Ngân sách";
            lblPhuongTien.Text = isEn ? "Transport" : "Phương tiện";
            chkDaHoanThanh.Text = isEn ? "Completed" : "Đã hoàn thành";

            btnThem.Text = isEn ? "Add" : "Thêm";
            btnSua.Text = isEn ? "Edit" : "Sửa";
            btnXoa.Text = isEn ? "Delete" : "Xóa";
            btnLamMoi.Text = isEn ? "Refresh" : "Làm mới";
            btnXemThoiTiet.Text = isEn ? "Check Weather" : "Xem thời tiết";
            btnTim.Text = isEn ? "Search" : "Tìm";
            chkChuaHoanThanh.Text = isEn ? "Show incomplete trips only" : "Chỉ hiện chuyến chưa hoàn thành";
            txtTimDiaDiem.PlaceholderText = isEn ? "Search location..." : "Tìm địa điểm...";

            LoadDataAsync();
        }

        // CRUD Chuyến đi (Task 3)
        private async void btnThem_Click(object sender, EventArgs e)
        {
            if (dtpNgayDi.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Ngày đi không được nhỏ hơn ngày hiện tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtNganSach.Text.Replace(".", "").Replace(",", ""), out decimal nganSach) || nganSach < 0)
            {
                MessageBox.Show("Ngân sách phải là số hợp lệ và >= 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new QLDaNgoaiContext(_connectionString);
                var item = new ChuyenDi
                {
                    TenChuyen = txtTenChuyen.Text.Trim(),
                    DiaDiem = txtDiaDiem.Text.Trim(),
                    NgayDi = dtpNgayDi.Value.Date,
                    SoNguoi = (int)nudSoNguoi.Value,
                    NganSach = nganSach,
                    PhuongTien = cboPhuongTien.SelectedItem?.ToString() ?? "Ô tô",
                    DaHoanThanh = chkDaHoanThanh.Checked
                };

                db.ChuyenDis.Add(item);
                await db.SaveChangesAsync();

                Log.Information("Thêm chuyến đi thành công: {TenChuyen}", item.TenChuyen);
                LoadDataAsync();
                ClearForm();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi thêm chuyến đi");
            }
        }

        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedMaChuyen == 0) return;

            if (!decimal.TryParse(txtNganSach.Text.Replace(".", "").Replace(",", ""), out decimal nganSach)) return;

            try
            {
                using var db = new QLDaNgoaiContext(_connectionString);
                var item = await db.ChuyenDis.FindAsync(_selectedMaChuyen);
                if (item != null)
                {
                    item.TenChuyen = txtTenChuyen.Text.Trim();
                    item.DiaDiem = txtDiaDiem.Text.Trim();
                    item.NgayDi = dtpNgayDi.Value.Date;
                    item.SoNguoi = (int)nudSoNguoi.Value;
                    item.NganSach = nganSach;
                    item.PhuongTien = cboPhuongTien.SelectedItem?.ToString() ?? "Ô tô";
                    item.DaHoanThanh = chkDaHoanThanh.Checked;

                    await db.SaveChangesAsync();
                    Log.Information("Cập nhật chuyến đi MaChuyen = {Ma}", _selectedMaChuyen);
                    LoadDataAsync();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi sửa chuyến đi");
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedMaChuyen == 0) return;

            if (MessageBox.Show("Bạn có muốn xóa chuyến đi này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using var db = new QLDaNgoaiContext(_connectionString);
                var item = await db.ChuyenDis.FindAsync(_selectedMaChuyen);
                if (item != null)
                {
                    db.ChuyenDis.Remove(item);
                    await db.SaveChangesAsync();
                    Log.Information("Xóa chuyến đi MaChuyen = {Ma}", _selectedMaChuyen);
                    LoadDataAsync();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Lỗi xóa chuyến đi");
            }
        }

        private void dgvChuyenDi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvChuyenDi.Rows[e.RowIndex];
                _selectedMaChuyen = Convert.ToInt32(row.Cells["MaChuyen"].Value);
                txtTenChuyen.Text = row.Cells["TenChuyen"].Value?.ToString();
                txtDiaDiem.Text = row.Cells["DiaDiem"].Value?.ToString();
                dtpNgayDi.Value = Convert.ToDateTime(row.Cells["NgayDi"].Value);
                nudSoNguoi.Value = Convert.ToInt32(row.Cells["SoNguoi"].Value);

                decimal ns = Convert.ToDecimal(row.Cells["NganSach"].Value);
                txtNganSach.Text = ns.ToString("N0");

                cboPhuongTien.SelectedItem = row.Cells["PhuongTien"].Value?.ToString();
                chkDaHoanThanh.Checked = Convert.ToBoolean(row.Cells["DaHoanThanh"].Value);
            }
        }

        private void btnTim_Click(object sender, EventArgs e) => LoadDataAsync();

        private void btnLamMoi_Click(object sender, EventArgs e) => ClearForm();

        private void ClearForm()
        {
            _selectedMaChuyen = 0;
            txtTenChuyen.Clear();
            txtDiaDiem.Clear();
            nudSoNguoi.Value = 6;
            txtNganSach.Text = "3.500.000";
            chkDaHoanThanh.Checked = false;
            dtpNgayDi.Value = new DateTime(2026, 10, 25);
        }

        // Hàm vẽ Icon Mây Mưa chuẩn nét GDI+
        private Bitmap DrawCloudIcon()
        {
            Bitmap bmp = new Bitmap(100, 80);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Vẽ mây đen/xám
                using Pen cloudPen = new Pen(Color.Black, 3.5f);
                g.DrawArc(cloudPen, 20, 20, 30, 30, 180, 180);
                g.DrawArc(cloudPen, 40, 10, 35, 35, 200, 160);
                g.DrawArc(cloudPen, 65, 25, 25, 25, 270, 180);
                g.DrawLine(cloudPen, 20, 50, 85, 50);

                // Vẽ các hạt mưa rào
                using Pen rainPen = new Pen(Color.Black, 3f);
                g.DrawLine(rainPen, 30, 58, 25, 70);
                g.DrawLine(rainPen, 48, 58, 43, 70);
                g.DrawLine(rainPen, 66, 58, 61, 70);
            }
            return bmp;
        }
    }
}