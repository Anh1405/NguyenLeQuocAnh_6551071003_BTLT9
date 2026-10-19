namespace QLNhaTroApp
{
    partial class FormKhachThue
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.RadioButton rdbNam;
        private System.Windows.Forms.RadioButton rdbNu;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblSoDienThoai;
        private System.Windows.Forms.TextBox txtSoDienThoai;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.ComboBox cboPhong;
        private System.Windows.Forms.Label lblTinhThanh;
        private System.Windows.Forms.ComboBox cboTinhThanh;
        private System.Windows.Forms.Label lblPhuongXa;
        private System.Windows.Forms.ComboBox cboPhuongXa;
        private System.Windows.Forms.TextBox txtPhuongXaManual;
        private System.Windows.Forms.CheckBox chkTamTru;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblLocPhong;
        private System.Windows.Forms.ComboBox cboLocPhong;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvKhachThue;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnGayLoiThu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.rdbNam = new System.Windows.Forms.RadioButton();
            this.rdbNu = new System.Windows.Forms.RadioButton();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblSoDienThoai = new System.Windows.Forms.Label();
            this.txtSoDienThoai = new System.Windows.Forms.TextBox();
            this.lblPhong = new System.Windows.Forms.Label();
            this.cboPhong = new System.Windows.Forms.ComboBox();
            this.lblTinhThanh = new System.Windows.Forms.Label();
            this.cboTinhThanh = new System.Windows.Forms.ComboBox();
            this.lblPhuongXa = new System.Windows.Forms.Label();
            this.cboPhuongXa = new System.Windows.Forms.ComboBox();
            this.txtPhuongXaManual = new System.Windows.Forms.TextBox();
            this.chkTamTru = new System.Windows.Forms.CheckBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblLocPhong = new System.Windows.Forms.Label();
            this.cboLocPhong = new System.Windows.Forms.ComboBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvKhachThue = new System.Windows.Forms.DataGridView();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnGayLoiThu = new System.Windows.Forms.Button();

            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachThue)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // 
            // grpThongTin
            // 
            this.grpThongTin.Controls.Add(this.lblHoTen);
            this.grpThongTin.Controls.Add(this.txtHoTen);
            this.grpThongTin.Controls.Add(this.rdbNam);
            this.grpThongTin.Controls.Add(this.rdbNu);
            this.grpThongTin.Controls.Add(this.lblNgaySinh);
            this.grpThongTin.Controls.Add(this.dtpNgaySinh);
            this.grpThongTin.Controls.Add(this.lblSoDienThoai);
            this.grpThongTin.Controls.Add(this.txtSoDienThoai);
            this.grpThongTin.Controls.Add(this.lblPhong);
            this.grpThongTin.Controls.Add(this.cboPhong);
            this.grpThongTin.Controls.Add(this.lblTinhThanh);
            this.grpThongTin.Controls.Add(this.cboTinhThanh);
            this.grpThongTin.Controls.Add(this.lblPhuongXa);
            this.grpThongTin.Controls.Add(this.cboPhuongXa);
            this.grpThongTin.Controls.Add(this.txtPhuongXaManual);
            this.grpThongTin.Controls.Add(this.chkTamTru);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Name = "grpThongTin";
            this.grpThongTin.Size = new System.Drawing.Size(380, 385);
            this.grpThongTin.TabIndex = 0;
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin khách thuê";

            // Họ tên
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(15, 32);
            this.lblHoTen.Text = "Họ tên";
            this.txtHoTen.Location = new System.Drawing.Point(110, 28);
            this.txtHoTen.Size = new System.Drawing.Size(255, 25);

            // Radio Nam / Nữ
            this.rdbNam.AutoSize = true;
            this.rdbNam.Checked = true;
            this.rdbNam.Location = new System.Drawing.Point(180, 62);
            this.rdbNam.Text = "Nam";
            this.rdbNu.AutoSize = true;
            this.rdbNu.Location = new System.Drawing.Point(250, 62);
            this.rdbNu.Text = "Nữ";

            // Ngày sinh
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(15, 100);
            this.lblNgaySinh.Text = "Ngày sinh";
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Location = new System.Drawing.Point(110, 96);
            this.dtpNgaySinh.Size = new System.Drawing.Size(255, 25);

            // Số điện thoại
            this.lblSoDienThoai.AutoSize = true;
            this.lblSoDienThoai.Location = new System.Drawing.Point(15, 138);
            this.lblSoDienThoai.Text = "Số điện thoại";
            this.txtSoDienThoai.Location = new System.Drawing.Point(110, 134);
            this.txtSoDienThoai.Size = new System.Drawing.Size(255, 25);

            // Phòng
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(15, 176);
            this.lblPhong.Text = "Phòng";
            this.cboPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhong.Location = new System.Drawing.Point(110, 172);
            this.cboPhong.Size = new System.Drawing.Size(255, 25);

            // Tỉnh/Thành
            this.lblTinhThanh.AutoSize = true;
            this.lblTinhThanh.Location = new System.Drawing.Point(15, 214);
            this.lblTinhThanh.Text = "Tỉnh/Thành";
            this.cboTinhThanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhThanh.Location = new System.Drawing.Point(110, 210);
            this.cboTinhThanh.Size = new System.Drawing.Size(255, 25);
            this.cboTinhThanh.SelectedIndexChanged += new System.EventHandler(this.cboTinhThanh_SelectedIndexChanged);

            // Phường/Xã
            this.lblPhuongXa.AutoSize = true;
            this.lblPhuongXa.Location = new System.Drawing.Point(15, 252);
            this.lblPhuongXa.Text = "Phường/Xã";
            this.cboPhuongXa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhuongXa.Location = new System.Drawing.Point(110, 248);
            this.cboPhuongXa.Size = new System.Drawing.Size(255, 25);

            this.txtPhuongXaManual.Location = new System.Drawing.Point(110, 248);
            this.txtPhuongXaManual.Size = new System.Drawing.Size(255, 25);
            this.txtPhuongXaManual.Visible = false;

            // CheckBox Tạm trú
            this.chkTamTru.AutoSize = true;
            this.chkTamTru.Location = new System.Drawing.Point(15, 338);
            this.chkTamTru.Text = "Đã đăng ký tạm trú";

            // 
            // Buttons Thêm / Sửa / Xóa / Làm mới
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 408);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(88, 32);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(108, 408);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(88, 32);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(204, 408);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(88, 32);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Location = new System.Drawing.Point(300, 408);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(92, 32);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // 
            // Tìm kiếm
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(405, 18);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(250, 25);
            this.txtTimKiem.PlaceholderText = "Tìm theo tên hoặc SĐT";

            this.lblLocPhong.AutoSize = true;
            this.lblLocPhong.Location = new System.Drawing.Point(670, 22);
            this.lblLocPhong.Text = "Phòng:";

            this.cboLocPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocPhong.Location = new System.Drawing.Point(725, 18);
            this.cboLocPhong.Size = new System.Drawing.Size(155, 25);

            this.btnTim.Location = new System.Drawing.Point(890, 16);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(95, 28);
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);

            // 
            // dgvKhachThue
            // 
            this.dgvKhachThue.AllowUserToAddRows = false;
            this.dgvKhachThue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachThue.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;

            this.dgvKhachThue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhachThue.ColumnHeadersHeight = 30;
            this.dgvKhachThue.Location = new System.Drawing.Point(405, 52);
            this.dgvKhachThue.MultiSelect = false;
            this.dgvKhachThue.Name = "dgvKhachThue";
            this.dgvKhachThue.ReadOnly = true;
            this.dgvKhachThue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachThue.Size = new System.Drawing.Size(580, 388);
            this.dgvKhachThue.TabIndex = 2;
            this.dgvKhachThue.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachThue_CellClick);

            // 
            // btnGayLoiThu (Nút ẩn thử nghiệm toàn cục)
            // 
            this.btnGayLoiThu.Location = new System.Drawing.Point(885, 442);
            this.btnGayLoiThu.Name = "btnGayLoiThu";
            this.btnGayLoiThu.Size = new System.Drawing.Size(100, 23);
            this.btnGayLoiThu.Text = "Gây lỗi thử";
            this.btnGayLoiThu.UseVisualStyleBackColor = true;
            this.btnGayLoiThu.Visible = false; // Có thể bật true nếu cần test nút ẩn
            this.btnGayLoiThu.Click += new System.EventHandler(this.btnGayLoiThu_Click);

            // 
            // StatusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip.Location = new System.Drawing.Point(0, 468);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(998, 22);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(240, 17);
            this.lblStatus.Text = "Đang tải dữ liệu...";

            // 
            // FormKhachThue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 490);
            this.Controls.Add(this.btnGayLoiThu);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dgvKhachThue);
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.cboLocPhong);
            this.Controls.Add(this.lblLocPhong);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.grpThongTin);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormKhachThue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý nhà trọ - Khách thuê";

            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachThue)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}