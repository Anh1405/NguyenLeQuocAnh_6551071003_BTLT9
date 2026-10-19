namespace QLTraSuaApp
{
    partial class FormBanHang
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpChonMon;
        private System.Windows.Forms.Label lblDanhMuc;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.ListBox lstMonUong;
        private System.Windows.Forms.Label lblSoLy;
        private System.Windows.Forms.NumericUpDown nudSoLy;
        private System.Windows.Forms.Button btnThemVaoDon;
        private System.Windows.Forms.GroupBox grpDonHang;
        private System.Windows.Forms.DataGridView dgvGioHang;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.GroupBox grpThanhToan;
        private System.Windows.Forms.Button btnChuyenKhoan;
        private System.Windows.Forms.Button btnTienMat;
        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblSoTienTitle;
        private System.Windows.Forms.Label lblSoTienVal;
        private System.Windows.Forms.Label lblNoiDungTitle;
        private System.Windows.Forms.Label lblNoiDungVal;
        private System.Windows.Forms.Button btnDaNhanTien;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpChonMon = new System.Windows.Forms.GroupBox();
            this.lblDanhMuc = new System.Windows.Forms.Label();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.lstMonUong = new System.Windows.Forms.ListBox();
            this.lblSoLy = new System.Windows.Forms.Label();
            this.nudSoLy = new System.Windows.Forms.NumericUpDown();
            this.btnThemVaoDon = new System.Windows.Forms.Button();
            this.grpDonHang = new System.Windows.Forms.GroupBox();
            this.dgvGioHang = new System.Windows.Forms.DataGridView();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.grpThanhToan = new System.Windows.Forms.GroupBox();
            this.btnChuyenKhoan = new System.Windows.Forms.Button();
            this.btnTienMat = new System.Windows.Forms.Button();
            this.picQR = new System.Windows.Forms.PictureBox();
            this.lblSoTienTitle = new System.Windows.Forms.Label();
            this.lblSoTienVal = new System.Windows.Forms.Label();
            this.lblNoiDungTitle = new System.Windows.Forms.Label();
            this.lblNoiDungVal = new System.Windows.Forms.Label();
            this.btnDaNhanTien = new System.Windows.Forms.Button();

            this.grpChonMon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLy)).BeginInit();
            this.grpDonHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).BeginInit();
            this.grpThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();

            // 
            // grpChonMon (Cột 1)
            // 
            this.grpChonMon.Controls.Add(this.lblDanhMuc);
            this.grpChonMon.Controls.Add(this.cboDanhMuc);
            this.grpChonMon.Controls.Add(this.lstMonUong);
            this.grpChonMon.Controls.Add(this.lblSoLy);
            this.grpChonMon.Controls.Add(this.nudSoLy);
            this.grpChonMon.Controls.Add(this.btnThemVaoDon);
            this.grpChonMon.Location = new System.Drawing.Point(12, 12);
            this.grpChonMon.Name = "grpChonMon";
            this.grpChonMon.Size = new System.Drawing.Size(250, 480);
            this.grpChonMon.Text = "Chọn món";

            this.lblDanhMuc.AutoSize = true;
            this.lblDanhMuc.Location = new System.Drawing.Point(10, 25);
            this.lblDanhMuc.Text = "Danh mục:";

            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Location = new System.Drawing.Point(10, 45);
            this.cboDanhMuc.Size = new System.Drawing.Size(230, 25);
            this.cboDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged);

            this.lstMonUong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lstMonUong.ItemHeight = 22;
            this.lstMonUong.Location = new System.Drawing.Point(10, 80);
            this.lstMonUong.Size = new System.Drawing.Size(230, 312);

            this.lblSoLy.AutoSize = true;
            this.lblSoLy.Location = new System.Drawing.Point(10, 404);
            this.lblSoLy.Text = "Số ly:";

            this.nudSoLy.Location = new System.Drawing.Point(110, 400);
            this.nudSoLy.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLy.Value = new decimal(new int[] { 2, 0, 0, 0 });
            this.nudSoLy.Size = new System.Drawing.Size(130, 25);

            this.btnThemVaoDon.Location = new System.Drawing.Point(10, 435);
            this.btnThemVaoDon.Name = "btnThemVaoDon";
            this.btnThemVaoDon.Size = new System.Drawing.Size(230, 35);
            this.btnThemVaoDon.Text = "Thêm vào đơn";
            this.btnThemVaoDon.UseVisualStyleBackColor = true;
            this.btnThemVaoDon.Click += new System.EventHandler(this.btnThemVaoDon_Click);

            // 
            // grpDonHang (Cột 2)
            // 
            this.grpDonHang.Controls.Add(this.dgvGioHang);
            this.grpDonHang.Controls.Add(this.btnXoaDong);
            this.grpDonHang.Controls.Add(this.lblTongTien);
            this.grpDonHang.Location = new System.Drawing.Point(270, 12);
            this.grpDonHang.Name = "grpDonHang";
            this.grpDonHang.Size = new System.Drawing.Size(430, 480);
            this.grpDonHang.Text = "Đơn hiện tại";

            this.dgvGioHang.AllowUserToAddRows = false;
            this.dgvGioHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGioHang.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvGioHang.EnableHeadersVisualStyles = false;

            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;

            this.dgvGioHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGioHang.ColumnHeadersHeight = 30;
            this.dgvGioHang.Location = new System.Drawing.Point(10, 25);
            this.dgvGioHang.MultiSelect = false;
            this.dgvGioHang.Name = "dgvGioHang";
            this.dgvGioHang.ReadOnly = true;
            this.dgvGioHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGioHang.Size = new System.Drawing.Size(410, 345);

            this.btnXoaDong.Location = new System.Drawing.Point(10, 380);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(410, 32);
            this.btnXoaDong.Text = "Xóa dòng";
            this.btnXoaDong.UseVisualStyleBackColor = true;
            this.btnXoaDong.Click += new System.EventHandler(this.btnXoaDong_Click);

            this.lblTongTien.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTongTien.ForeColor = System.Drawing.Color.Black;
            this.lblTongTien.Location = new System.Drawing.Point(10, 425);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(410, 45);
            this.lblTongTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTongTien.Text = "Tổng tiền: 120.000 đ";

            // 
            // grpThanhToan (Cột 3)
            // 
            this.grpThanhToan.Controls.Add(this.btnChuyenKhoan);
            this.grpThanhToan.Controls.Add(this.btnTienMat);
            this.grpThanhToan.Controls.Add(this.picQR);
            this.grpThanhToan.Controls.Add(this.lblSoTienTitle);
            this.grpThanhToan.Controls.Add(this.lblSoTienVal);
            this.grpThanhToan.Controls.Add(this.lblNoiDungTitle);
            this.grpThanhToan.Controls.Add(this.lblNoiDungVal);
            this.grpThanhToan.Controls.Add(this.btnDaNhanTien);
            this.grpThanhToan.Location = new System.Drawing.Point(710, 12);
            this.grpThanhToan.Name = "grpThanhToan";
            this.grpThanhToan.Size = new System.Drawing.Size(260, 480);
            this.grpThanhToan.Text = "Thanh toán";

            this.btnChuyenKhoan.Location = new System.Drawing.Point(10, 25);
            this.btnChuyenKhoan.Name = "btnChuyenKhoan";
            this.btnChuyenKhoan.Size = new System.Drawing.Size(240, 35);
            this.btnChuyenKhoan.Text = "Thanh toán chuyển khoản";
            this.btnChuyenKhoan.UseVisualStyleBackColor = true;
            this.btnChuyenKhoan.Click += new System.EventHandler(this.btnChuyenKhoan_Click);

            this.btnTienMat.Location = new System.Drawing.Point(10, 68);
            this.btnTienMat.Name = "btnTienMat";
            this.btnTienMat.Size = new System.Drawing.Size(240, 30);
            this.btnTienMat.Text = "Tiền mặt";
            this.btnTienMat.UseVisualStyleBackColor = true;
            this.btnTienMat.Click += new System.EventHandler(this.btnTienMat_Click);

            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Location = new System.Drawing.Point(20, 108);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(220, 240);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // Số tiền
            this.lblSoTienTitle.AutoSize = true;
            this.lblSoTienTitle.Location = new System.Drawing.Point(15, 358);
            this.lblSoTienTitle.Text = "Số tiền:";

            this.lblSoTienVal.AutoSize = true;
            this.lblSoTienVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSoTienVal.Location = new System.Drawing.Point(100, 358);
            this.lblSoTienVal.Text = "120.000 đ";

            // Nội dung
            this.lblNoiDungTitle.AutoSize = true;
            this.lblNoiDungTitle.Location = new System.Drawing.Point(15, 388);
            this.lblNoiDungTitle.Text = "Nội dung:";

            this.lblNoiDungVal.AutoSize = true;
            this.lblNoiDungVal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNoiDungVal.Location = new System.Drawing.Point(100, 388);
            this.lblNoiDungVal.Text = "TRASUA HD1024";

            // Nút "Đã nhận tiền" màu xanh cây
            this.btnDaNhanTien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(128)))), ((int)(((byte)(61)))));
            this.btnDaNhanTien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDaNhanTien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDaNhanTien.ForeColor = System.Drawing.Color.White;
            this.btnDaNhanTien.Location = new System.Drawing.Point(10, 428);
            this.btnDaNhanTien.Name = "btnDaNhanTien";
            this.btnDaNhanTien.Size = new System.Drawing.Size(240, 42);
            this.btnDaNhanTien.Text = "Đã nhận tiền";
            this.btnDaNhanTien.UseVisualStyleBackColor = false;
            this.btnDaNhanTien.Click += new System.EventHandler(this.btnDaNhanTien_Click);

            // 
            // FormBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 505);
            this.Controls.Add(this.grpThanhToan);
            this.Controls.Add(this.grpDonHang);
            this.Controls.Add(this.grpChonMon);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán hàng - Quán trà sữa";

            this.grpChonMon.ResumeLayout(false);
            this.grpChonMon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLy)).EndInit();
            this.grpDonHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGioHang)).EndInit();
            this.grpThanhToan.ResumeLayout(false);
            this.grpThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
        }
    }
}