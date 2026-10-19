namespace QLChiTieuApp
{
    partial class FormChiTieu
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblNgayChi;
        private System.Windows.Forms.DateTimePicker dtpNgayChi;
        private System.Windows.Forms.Label lblNoiDung;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label lblLoaiChi;
        private System.Windows.Forms.ComboBox cboLoaiChi;
        private System.Windows.Forms.Label lblLoaiChiExtra;
        private System.Windows.Forms.ComboBox cboLoaiChiExtra;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.NumericUpDown nudSoTien;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.GroupBox grpTimKiem;
        private System.Windows.Forms.Label lblTimTextBox;
        private System.Windows.Forms.TextBox txtTimNoiDung;
        private System.Windows.Forms.Label lblLocLoaiChi;
        private System.Windows.Forms.ComboBox cboLocLoaiChi;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvChiTieu;
        private System.Windows.Forms.Label lblTongChi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblNgayChi = new System.Windows.Forms.Label();
            this.dtpNgayChi = new System.Windows.Forms.DateTimePicker();
            this.lblLoaiChiExtra = new System.Windows.Forms.Label();
            this.cboLoaiChiExtra = new System.Windows.Forms.ComboBox();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.nudSoTien = new System.Windows.Forms.NumericUpDown();
            this.lblLoaiChi = new System.Windows.Forms.Label();
            this.cboLoaiChi = new System.Windows.Forms.ComboBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.grpTimKiem = new System.Windows.Forms.GroupBox();
            this.lblTimTextBox = new System.Windows.Forms.Label();
            this.txtTimNoiDung = new System.Windows.Forms.TextBox();
            this.lblLocLoaiChi = new System.Windows.Forms.Label();
            this.cboLocLoaiChi = new System.Windows.Forms.ComboBox();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvChiTieu = new System.Windows.Forms.DataGridView();
            this.lblTongChi = new System.Windows.Forms.Label();

            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTien)).BeginInit();
            this.grpTimKiem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).BeginInit();
            this.SuspendLayout();

            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblNgayChi);
            this.grpThongTin.Controls.Add(this.dtpNgayChi);
            this.grpThongTin.Controls.Add(this.lblLoaiChiExtra);
            this.grpThongTin.Controls.Add(this.cboLoaiChiExtra);
            this.grpThongTin.Controls.Add(this.lblNoiDung);
            this.grpThongTin.Controls.Add(this.txtNoiDung);
            this.grpThongTin.Controls.Add(this.lblSoTien);
            this.grpThongTin.Controls.Add(this.nudSoTien);
            this.grpThongTin.Controls.Add(this.lblLoaiChi);
            this.grpThongTin.Controls.Add(this.cboLoaiChi);
            this.grpThongTin.Controls.Add(this.lblGhiChu);
            this.grpThongTin.Controls.Add(this.txtGhiChu);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(570, 195);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin khoản chi";

            // lblNgayChi & dtpNgayChi
            this.lblNgayChi.AutoSize = true;
            this.lblNgayChi.Location = new System.Drawing.Point(15, 30);
            this.lblNgayChi.Text = "Ngày chi";
            this.dtpNgayChi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayChi.Location = new System.Drawing.Point(85, 26);
            this.dtpNgayChi.Size = new System.Drawing.Size(165, 23);

            // lblLoaiChiExtra & cboLoaiChiExtra
            this.lblLoaiChiExtra.AutoSize = true;
            this.lblLoaiChiExtra.Location = new System.Drawing.Point(270, 30);
            this.lblLoaiChiExtra.Text = "Loại chi:";
            this.cboLoaiChiExtra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiChiExtra.Items.AddRange(new object[] { "Tàn uống", "Ăn uống", "Đi lại", "Học tập" });
            this.cboLoaiChiExtra.Location = new System.Drawing.Point(340, 26);
            this.cboLoaiChiExtra.Size = new System.Drawing.Size(210, 23);

            // lblNoiDung & txtNoiDung
            this.lblNoiDung.AutoSize = true;
            this.lblNoiDung.Location = new System.Drawing.Point(15, 65);
            this.lblNoiDung.Text = "Nội dung";
            this.txtNoiDung.Location = new System.Drawing.Point(85, 61);
            this.txtNoiDung.Size = new System.Drawing.Size(165, 23);

            // lblSoTien & nudSoTien
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(270, 65);
            this.lblSoTien.Text = "Số tiền";
            this.nudSoTien.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudSoTien.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudSoTien.Location = new System.Drawing.Point(340, 61);
            this.nudSoTien.Size = new System.Drawing.Size(210, 23);

            // lblLoaiChi & cboLoaiChi
            this.lblLoaiChi.AutoSize = true;
            this.lblLoaiChi.Location = new System.Drawing.Point(15, 100);
            this.lblLoaiChi.Text = "Loại chi";
            this.cboLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiChi.Items.AddRange(new object[] { "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác" });
            this.cboLoaiChi.Location = new System.Drawing.Point(85, 96);
            this.cboLoaiChi.Size = new System.Drawing.Size(165, 23);

            // lblGhiChu & txtGhiChu
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(15, 135);
            this.lblGhiChu.Text = "Ghi chú";
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Location = new System.Drawing.Point(85, 131);
            this.txtGhiChu.Size = new System.Drawing.Size(465, 50);

            // 
            // grpTimKiem
            // 
            this.grpTimKiem.Controls.Add(this.lblTimTextBox);
            this.grpTimKiem.Controls.Add(this.txtTimNoiDung);
            this.grpTimKiem.Controls.Add(this.lblLocLoaiChi);
            this.grpTimKiem.Controls.Add(this.cboLocLoaiChi);
            this.grpTimKiem.Controls.Add(this.lblTuNgay);
            this.grpTimKiem.Controls.Add(this.dtpTuNgay);
            this.grpTimKiem.Controls.Add(this.lblDenNgay);
            this.grpTimKiem.Controls.Add(this.dtpDenNgay);
            this.grpTimKiem.Controls.Add(this.btnTim);
            this.grpTimKiem.Location = new System.Drawing.Point(595, 12);
            this.grpTimKiem.Name = "grpTimKiem";
            this.grpTimKiem.Size = new System.Drawing.Size(373, 195);
            this.grpTimKiem.TabIndex = 1;
            this.grpTimKiem.TabStop = false;
            this.grpTimKiem.Text = "Tìm kiếm";

            // lblTimTextBox & txtTimNoiDung
            this.lblTimTextBox.AutoSize = true;
            this.lblTimTextBox.Location = new System.Drawing.Point(15, 30);
            this.lblTimTextBox.Text = "TextBox";
            this.txtTimNoiDung.Location = new System.Drawing.Point(85, 26);
            this.txtTimNoiDung.Size = new System.Drawing.Size(270, 23);
            this.txtTimNoiDung.PlaceholderText = "Nhập nội dung...";

            // lblLocLoaiChi & cboLocLoaiChi
            this.lblLocLoaiChi.AutoSize = true;
            this.lblLocLoaiChi.Location = new System.Drawing.Point(15, 65);
            this.lblLocLoaiChi.Text = "Loại chi";
            this.cboLocLoaiChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocLoaiChi.Items.AddRange(new object[] { "Tất cả", "Ăn uống", "Đi lại", "Học tập", "Giải trí", "Khác" });
            this.cboLocLoaiChi.Location = new System.Drawing.Point(85, 61);
            this.cboLocLoaiChi.Size = new System.Drawing.Size(270, 23);

            // lblTuNgay & dtpTuNgay
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(15, 100);
            this.lblTuNgay.Text = "Từ ngày";
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(85, 96);
            this.dtpTuNgay.Size = new System.Drawing.Size(150, 23);

            // lblDenNgay & dtpDenNgay & btnTim
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(15, 135);
            this.lblDenNgay.Text = "Đến ngày";
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(85, 131);
            this.dtpDenNgay.Size = new System.Drawing.Size(150, 23);

            this.btnTim.Location = new System.Drawing.Point(250, 130);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(105, 26);
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);

            // 
            // Buttons Thêm / Sửa / Xóa / Làm mới
            // 
            this.btnThem.Location = new System.Drawing.Point(115, 218);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 32);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(220, 218);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 32);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(325, 218);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 32);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Location = new System.Drawing.Point(430, 218);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(95, 32);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // dgvChiTieu
            // 
            this.dgvChiTieu.AllowUserToAddRows = false;
            this.dgvChiTieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTieu.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(220)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            this.dgvChiTieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTieu.ColumnHeadersHeight = 32;
            this.dgvChiTieu.Location = new System.Drawing.Point(12, 262);
            this.dgvChiTieu.MultiSelect = false;
            this.dgvChiTieu.Name = "dgvChiTieu";
            this.dgvChiTieu.ReadOnly = true;
            this.dgvChiTieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTieu.Size = new System.Drawing.Size(956, 240);
            this.dgvChiTieu.TabIndex = 2;
            this.dgvChiTieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTieu_CellClick);

            // 
            // lblTongChi
            // 
            this.lblTongChi.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongChi.ForeColor = System.Drawing.Color.Red;
            this.lblTongChi.Location = new System.Drawing.Point(550, 510);
            this.lblTongChi.Name = "lblTongChi";
            this.lblTongChi.Size = new System.Drawing.Size(418, 35);
            this.lblTongChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTongChi.Text = "Tổng chi: 1.250.000 đ";

            // 
            // FormChiTieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 555);
            this.Controls.Add(this.lblTongChi);
            this.Controls.Add(this.dgvChiTieu);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpTimKiem);
            this.Controls.Add(this.grpThongTin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormChiTieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sổ chi tiêu cá nhân";

            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTien)).EndInit();
            this.grpTimKiem.ResumeLayout(false);
            this.grpTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTieu)).EndInit();
            this.ResumeLayout(false);
        }
    }
}