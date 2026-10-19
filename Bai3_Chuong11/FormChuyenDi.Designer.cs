namespace QLDaNgoaiApp
{
    partial class FormChuyenDi
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblNgonNgu;
        private System.Windows.Forms.ComboBox cboNgonNgu;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblTenChuyen;
        private System.Windows.Forms.TextBox txtTenChuyen;
        private System.Windows.Forms.Label lblDiaDiem;
        private System.Windows.Forms.TextBox txtDiaDiem;
        private System.Windows.Forms.Label lblNgayDi;
        private System.Windows.Forms.DateTimePicker dtpNgayDi;
        private System.Windows.Forms.Label lblSoNguoi;
        private System.Windows.Forms.NumericUpDown nudSoNguoi;
        private System.Windows.Forms.Label lblNganSach;
        private System.Windows.Forms.TextBox txtNganSach;
        private System.Windows.Forms.Label lblPhuongTien;
        private System.Windows.Forms.ComboBox cboPhuongTien;
        private System.Windows.Forms.CheckBox chkDaHoanThanh;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemThoiTiet;
        private System.Windows.Forms.ProgressBar pbLoading;
        private System.Windows.Forms.Panel pnlThoiTiet;
        private System.Windows.Forms.Label lblThoiTietTitle;
        private System.Windows.Forms.Label lblMoTaThoiTiet;
        private System.Windows.Forms.Label lblNhietDo;
        private System.Windows.Forms.Label lblKhaNangMua;
        private System.Windows.Forms.Panel pnlCanhBao;
        private System.Windows.Forms.Label lblIconCanhBao;
        private System.Windows.Forms.Label lblCanhBaoText;
        private System.Windows.Forms.PictureBox picCloudIcon;
        private System.Windows.Forms.TextBox txtTimDiaDiem;
        private System.Windows.Forms.CheckBox chkChuaHoanThanh;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvChuyenDi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblNgonNgu = new System.Windows.Forms.Label();
            this.cboNgonNgu = new System.Windows.Forms.ComboBox();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblTenChuyen = new System.Windows.Forms.Label();
            this.txtTenChuyen = new System.Windows.Forms.TextBox();
            this.lblDiaDiem = new System.Windows.Forms.Label();
            this.txtDiaDiem = new System.Windows.Forms.TextBox();
            this.lblNgayDi = new System.Windows.Forms.Label();
            this.dtpNgayDi = new System.Windows.Forms.DateTimePicker();
            this.lblSoNguoi = new System.Windows.Forms.Label();
            this.nudSoNguoi = new System.Windows.Forms.NumericUpDown();
            this.lblNganSach = new System.Windows.Forms.Label();
            this.txtNganSach = new System.Windows.Forms.TextBox();
            this.lblPhuongTien = new System.Windows.Forms.Label();
            this.cboPhuongTien = new System.Windows.Forms.ComboBox();
            this.chkDaHoanThanh = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXemThoiTiet = new System.Windows.Forms.Button();
            this.pbLoading = new System.Windows.Forms.ProgressBar();
            this.pnlThoiTiet = new System.Windows.Forms.Panel();
            this.lblThoiTietTitle = new System.Windows.Forms.Label();
            this.picCloudIcon = new System.Windows.Forms.PictureBox();
            this.lblMoTaThoiTiet = new System.Windows.Forms.Label();
            this.lblNhietDo = new System.Windows.Forms.Label();
            this.lblKhaNangMua = new System.Windows.Forms.Label();
            this.pnlCanhBao = new System.Windows.Forms.Panel();
            this.lblIconCanhBao = new System.Windows.Forms.Label();
            this.lblCanhBaoText = new System.Windows.Forms.Label();
            this.txtTimDiaDiem = new System.Windows.Forms.TextBox();
            this.chkChuaHoanThanh = new System.Windows.Forms.CheckBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvChuyenDi = new System.Windows.Forms.DataGridView();

            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoNguoi)).BeginInit();
            this.pnlThoiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloudIcon)).BeginInit();
            this.pnlCanhBao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenDi)).BeginInit();
            this.SuspendLayout();

            // 
            // lblHeaderTitle (Tiêu đề trên cùng)
            // 
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHeaderTitle.Location = new System.Drawing.Point(12, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(292, 30);
            this.lblHeaderTitle.Text = "Kế hoạch dã ngoại cuối tuần";

            // 
            // Ngôn ngữ
            // 
            this.lblNgonNgu.AutoSize = true;
            this.lblNgonNgu.Location = new System.Drawing.Point(795, 20);
            this.lblNgonNgu.Text = "Ngôn ngữ";

            this.cboNgonNgu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNgonNgu.Items.AddRange(new object[] { "Tiếng Việt", "English" });
            this.cboNgonNgu.Location = new System.Drawing.Point(865, 16);
            this.cboNgonNgu.Size = new System.Drawing.Size(115, 25);
            this.cboNgonNgu.SelectedIndexChanged += new System.EventHandler(this.cboNgonNgu_SelectedIndexChanged);

            // 
            // grpThongTin (Khung trái)
            // 
            this.grpThongTin.Controls.Add(this.lblTenChuyen);
            this.grpThongTin.Controls.Add(this.txtTenChuyen);
            this.grpThongTin.Controls.Add(this.lblDiaDiem);
            this.grpThongTin.Controls.Add(this.txtDiaDiem);
            this.grpThongTin.Controls.Add(this.lblNgayDi);
            this.grpThongTin.Controls.Add(this.dtpNgayDi);
            this.grpThongTin.Controls.Add(this.lblSoNguoi);
            this.grpThongTin.Controls.Add(this.nudSoNguoi);
            this.grpThongTin.Controls.Add(this.lblNganSach);
            this.grpThongTin.Controls.Add(this.txtNganSach);
            this.grpThongTin.Controls.Add(this.lblPhuongTien);
            this.grpThongTin.Controls.Add(this.cboPhuongTien);
            this.grpThongTin.Controls.Add(this.chkDaHoanThanh);
            this.grpThongTin.Location = new System.Drawing.Point(12, 50);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(550, 280);
            this.grpThongTin.Text = "Thông tin chuyến đi";

            // Tên chuyến
            this.lblTenChuyen.AutoSize = true;
            this.lblTenChuyen.Location = new System.Drawing.Point(15, 30);
            this.lblTenChuyen.Text = "Tên chuyến";
            this.txtTenChuyen.Location = new System.Drawing.Point(110, 26);
            this.txtTenChuyen.Size = new System.Drawing.Size(420, 25);

            // Địa điểm
            this.lblDiaDiem.AutoSize = true;
            this.lblDiaDiem.Location = new System.Drawing.Point(15, 68);
            this.lblDiaDiem.Text = "Địa điểm";
            this.txtDiaDiem.Location = new System.Drawing.Point(110, 64);
            this.txtDiaDiem.Size = new System.Drawing.Size(420, 25);

            // Ngày đi
            this.lblNgayDi.AutoSize = true;
            this.lblNgayDi.Location = new System.Drawing.Point(15, 106);
            this.lblNgayDi.Text = "Ngày đi";
            this.dtpNgayDi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayDi.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayDi.Location = new System.Drawing.Point(110, 102);
            this.dtpNgayDi.Size = new System.Drawing.Size(140, 25);

            // Số người
            this.lblSoNguoi.AutoSize = true;
            this.lblSoNguoi.Location = new System.Drawing.Point(15, 144);
            this.lblSoNguoi.Text = "Số người";
            this.nudSoNguoi.Minimum = 1;
            this.nudSoNguoi.Value = 6;
            this.nudSoNguoi.Location = new System.Drawing.Point(110, 140);
            this.nudSoNguoi.Size = new System.Drawing.Size(140, 25);

            // Ngân sách
            this.lblNganSach.AutoSize = true;
            this.lblNganSach.Location = new System.Drawing.Point(15, 182);
            this.lblNganSach.Text = "Ngân sách";
            this.txtNganSach.Location = new System.Drawing.Point(110, 178);
            this.txtNganSach.Size = new System.Drawing.Size(140, 25);

            // Phương tiện
            this.lblPhuongTien.AutoSize = true;
            this.lblPhuongTien.Location = new System.Drawing.Point(15, 220);
            this.lblPhuongTien.Text = "Phương tiện";
            this.cboPhuongTien.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongTien.Items.AddRange(new object[] { "Ô tô", "Xe máy", "Xe khách", "Tàu hỏa" });
            this.cboPhuongTien.Location = new System.Drawing.Point(110, 216);
            this.cboPhuongTien.Size = new System.Drawing.Size(140, 25);

            // CheckBox Đã hoàn thành
            this.chkDaHoanThanh.AutoSize = true;
            this.chkDaHoanThanh.Location = new System.Drawing.Point(15, 252);
            this.chkDaHoanThanh.Text = "Đã hoàn thành";

            // 
            // Buttons Thêm / Sửa / Xóa / Làm mới
            // 
            this.btnThem.Location = new System.Drawing.Point(20, 342);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(120, 34);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(155, 342);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(120, 34);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(290, 342);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(120, 34);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Location = new System.Drawing.Point(425, 342);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(120, 34);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // Xem thời tiết & ProgressBar Marquee
            // 
            this.btnXemThoiTiet.Location = new System.Drawing.Point(580, 50);
            this.btnXemThoiTiet.Name = "btnXemThoiTiet";
            this.btnXemThoiTiet.Size = new System.Drawing.Size(140, 32);
            this.btnXemThoiTiet.Text = "Xem thời tiết";
            this.btnXemThoiTiet.UseVisualStyleBackColor = true;
            this.btnXemThoiTiet.Click += new System.EventHandler(this.btnXemThoiTiet_Click);

            this.pbLoading.Location = new System.Drawing.Point(730, 58);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(250, 16);
            this.pbLoading.Visible = false;

            // 
            // pnlThoiTiet (Khung dự báo thời tiết bên phải)
            // 
            this.pnlThoiTiet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThoiTiet.Controls.Add(this.lblThoiTietTitle);
            this.pnlThoiTiet.Controls.Add(this.picCloudIcon);
            this.pnlThoiTiet.Controls.Add(this.lblMoTaThoiTiet);
            this.pnlThoiTiet.Controls.Add(this.lblNhietDo);
            this.pnlThoiTiet.Controls.Add(this.lblKhaNangMua);
            this.pnlThoiTiet.Controls.Add(this.pnlCanhBao);
            this.pnlThoiTiet.Location = new System.Drawing.Point(580, 90);
            this.pnlThoiTiet.Name = "pnlThoiTiet";
            this.pnlThoiTiet.Size = new System.Drawing.Size(400, 240);

            // Tiêu đề Dự báo
            this.lblThoiTietTitle.AutoSize = true;
            this.lblThoiTietTitle.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblThoiTietTitle.Location = new System.Drawing.Point(10, 10);
            this.lblThoiTietTitle.Text = "Dự báo thời tiết ngày 25/10/2026 - Đà Lạt";

            // Icon Mây / Mưa
            this.picCloudIcon.Location = new System.Drawing.Point(30, 45);
            this.picCloudIcon.Size = new System.Drawing.Size(100, 80);
            this.picCloudIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // Mô tả
            this.lblMoTaThoiTiet.AutoSize = true;
            this.lblMoTaThoiTiet.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMoTaThoiTiet.Location = new System.Drawing.Point(155, 45);
            this.lblMoTaThoiTiet.Text = "Mưa rào nhẹ";

            // Nhiệt độ & Khả năng mưa
            this.lblNhietDo.AutoSize = true;
            this.lblNhietDo.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNhietDo.Location = new System.Drawing.Point(155, 80);
            this.lblNhietDo.Text = "Nhiệt độ: 14°C - 22°C";

            this.lblKhaNangMua.AutoSize = true;
            this.lblKhaNangMua.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKhaNangMua.Location = new System.Drawing.Point(155, 105);
            this.lblKhaNangMua.Text = "Khả năng mưa: 75%";

            // Khung Cảnh báo màu cam
            this.pnlCanhBao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(215)))), ((int)(((byte)(170)))));
            this.pnlCanhBao.Controls.Add(this.lblIconCanhBao);
            this.pnlCanhBao.Controls.Add(this.lblCanhBaoText);
            this.pnlCanhBao.Location = new System.Drawing.Point(20, 155);
            this.pnlCanhBao.Name = "pnlCanhBao";
            this.pnlCanhBao.Size = new System.Drawing.Size(360, 45);

            this.lblIconCanhBao.AutoSize = true;
            this.lblIconCanhBao.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIconCanhBao.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(65)))), ((int)(((byte)(12)))));
            this.lblIconCanhBao.Location = new System.Drawing.Point(12, 10);
            this.lblIconCanhBao.Text = "!";

            this.lblCanhBaoText.AutoSize = true;
            this.lblCanhBaoText.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCanhBaoText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(45)))), ((int)(((byte)(18)))));
            this.lblCanhBaoText.Location = new System.Drawing.Point(35, 12);
            this.lblCanhBaoText.Text = "Nên mang áo mưa hoặc cân nhắc dời lịch";

            // 
            // Thanh Tìm kiếm & Lọc bên dưới
            // 
            this.txtTimDiaDiem.Location = new System.Drawing.Point(12, 395);
            this.txtTimDiaDiem.Name = "txtTimDiaDiem";
            this.txtTimDiaDiem.Size = new System.Drawing.Size(240, 25);
            this.txtTimDiaDiem.PlaceholderText = "Tìm địa điểm...";

            this.chkChuaHoanThanh.AutoSize = true;
            this.chkChuaHoanThanh.Location = new System.Drawing.Point(265, 397);
            this.chkChuaHoanThanh.Text = "Chỉ hiện chuyến chưa hoàn thành";

            this.btnTim.Location = new System.Drawing.Point(525, 392);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(100, 30);
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);

            // 
            // dgvChuyenDi
            // 
            this.dgvChuyenDi.AllowUserToAddRows = false;
            this.dgvChuyenDi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChuyenDi.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;

            this.dgvChuyenDi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChuyenDi.ColumnHeadersHeight = 30;
            this.dgvChuyenDi.Location = new System.Drawing.Point(12, 430);
            this.dgvChuyenDi.MultiSelect = false;
            this.dgvChuyenDi.Name = "dgvChuyenDi";
            this.dgvChuyenDi.ReadOnly = true;
            this.dgvChuyenDi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChuyenDi.Size = new System.Drawing.Size(968, 220);
            this.dgvChuyenDi.TabIndex = 2;
            this.dgvChuyenDi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChuyenDi_CellClick);

            // 
            // FormChuyenDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 665);
            this.Controls.Add(this.dgvChuyenDi);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.chkChuaHoanThanh);
            this.Controls.Add(this.txtTimDiaDiem);
            this.Controls.Add(this.pnlThoiTiet);
            this.Controls.Add(this.pbLoading);
            this.Controls.Add(this.btnXemThoiTiet);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpThongTin);
            this.Controls.Add(this.cboNgonNgu);
            this.Controls.Add(this.lblNgonNgu);
            this.Controls.Add(this.lblHeaderTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormChuyenDi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kế hoạch dã ngoại cuối tuần";

            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoNguoi)).EndInit();
            this.pnlThoiTiet.ResumeLayout(false);
            this.pnlThoiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCloudIcon)).EndInit();
            this.pnlCanhBao.ResumeLayout(false);
            this.pnlCanhBao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChuyenDi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}