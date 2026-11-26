namespace _6_6_BankAtmMdiSystem.GUI
{
    partial class frmAtmStations
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpThongTin;
        private System.Windows.Forms.Label lblMaTram;
        private System.Windows.Forms.TextBox txtMaTram;
        private System.Windows.Forms.Label lblDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lblTonQuy;
        private System.Windows.Forms.NumericUpDown numTonQuy;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboTrangThai;

        private System.Windows.Forms.GroupBox grpAnhHienTruong;
        private System.Windows.Forms.PictureBox picHienTruong;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Label lblDuongDanAnh;

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;

        private System.Windows.Forms.DataGridView dgvAtmStations;
        private System.Windows.Forms.OpenFileDialog ofdAnhHienTruong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.grpThongTin = new System.Windows.Forms.GroupBox();
            this.lblMaTram = new System.Windows.Forms.Label();
            this.txtMaTram = new System.Windows.Forms.TextBox();
            this.lblDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lblTonQuy = new System.Windows.Forms.Label();
            this.numTonQuy = new System.Windows.Forms.NumericUpDown();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.cboTrangThai = new System.Windows.Forms.ComboBox();

            this.grpAnhHienTruong = new System.Windows.Forms.GroupBox();
            this.picHienTruong = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.lblDuongDanAnh = new System.Windows.Forms.Label();

            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();

            this.dgvAtmStations = new System.Windows.Forms.DataGridView();
            this.ofdAnhHienTruong = new System.Windows.Forms.OpenFileDialog();

            this.grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTonQuy)).BeginInit();
            this.grpAnhHienTruong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHienTruong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtmStations)).BeginInit();
            this.SuspendLayout();

            // GroupBox Thông tin trạm ATM
            this.grpThongTin.Controls.Add(this.lblMaTram);
            this.grpThongTin.Controls.Add(this.txtMaTram);
            this.grpThongTin.Controls.Add(this.lblDiaChi);
            this.grpThongTin.Controls.Add(this.txtDiaChi);
            this.grpThongTin.Controls.Add(this.lblTonQuy);
            this.grpThongTin.Controls.Add(this.numTonQuy);
            this.grpThongTin.Controls.Add(this.lblTrangThai);
            this.grpThongTin.Controls.Add(this.cboTrangThai);
            this.grpThongTin.Controls.Add(this.btnThem);
            this.grpThongTin.Controls.Add(this.btnCapNhat);
            this.grpThongTin.Controls.Add(this.btnXoa);
            this.grpThongTin.Controls.Add(this.btnLamMoi);
            this.grpThongTin.Location = new System.Drawing.Point(12, 12);
            this.grpThongTin.Size = new System.Drawing.Size(540, 230);
            this.grpThongTin.TabStop = false;
            this.grpThongTin.Text = "Thông tin Trạm ATM & Tồn quỹ";

            this.lblMaTram.AutoSize = true;
            this.lblMaTram.Location = new System.Drawing.Point(16, 32);
            this.lblMaTram.Text = "Mã trạm ATM:";

            this.txtMaTram.Location = new System.Drawing.Point(150, 29);
            this.txtMaTram.Size = new System.Drawing.Size(365, 23);

            this.lblDiaChi.AutoSize = true;
            this.lblDiaChi.Location = new System.Drawing.Point(16, 68);
            this.lblDiaChi.Text = "Địa chỉ đặt máy:";

            this.txtDiaChi.Location = new System.Drawing.Point(150, 65);
            this.txtDiaChi.Size = new System.Drawing.Size(365, 23);

            this.lblTonQuy.AutoSize = true;
            this.lblTonQuy.Location = new System.Drawing.Point(16, 104);
            this.lblTonQuy.Text = "Tồn quỹ hiện tại (VNĐ):";

            this.numTonQuy.Increment = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.numTonQuy.Location = new System.Drawing.Point(150, 101);
            this.numTonQuy.Maximum = new decimal(new int[] { 1215752192, 23, 0, 0 });
            this.numTonQuy.Size = new System.Drawing.Size(365, 23);
            this.numTonQuy.ThousandsSeparator = true;

            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(16, 140);
            this.lblTrangThai.Text = "Trạng thái hoạt động:";

            this.cboTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTrangThai.Items.AddRange(new object[] {
                "Hoạt động bình thường",
                "Sắp hết tiền quỹ",
                "Đang bảo trì kỹ thuật",
                "Ngừng hoạt động"
            });
            this.cboTrangThai.Location = new System.Drawing.Point(150, 137);
            this.cboTrangThai.Size = new System.Drawing.Size(365, 23);

            this.btnThem.Location = new System.Drawing.Point(150, 180);
            this.btnThem.Size = new System.Drawing.Size(85, 32);
            this.btnThem.Text = "Thêm trạm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnCapNhat.Location = new System.Drawing.Point(243, 180);
            this.btnCapNhat.Size = new System.Drawing.Size(85, 32);
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);

            this.btnXoa.Location = new System.Drawing.Point(336, 180);
            this.btnXoa.Size = new System.Drawing.Size(85, 32);
            this.btnXoa.Text = "Xóa trạm";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Location = new System.Drawing.Point(430, 180);
            this.btnLamMoi.Size = new System.Drawing.Size(85, 32);
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            // GroupBox Ảnh chụp hiện trường
            this.grpAnhHienTruong.Controls.Add(this.picHienTruong);
            this.grpAnhHienTruong.Controls.Add(this.btnChonAnh);
            this.grpAnhHienTruong.Controls.Add(this.lblDuongDanAnh);
            this.grpAnhHienTruong.Location = new System.Drawing.Point(565, 12);
            this.grpAnhHienTruong.Size = new System.Drawing.Size(345, 230);
            this.grpAnhHienTruong.TabStop = false;
            this.grpAnhHienTruong.Text = "Ảnh chụp hiện trường trạm ATM";

            this.picHienTruong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHienTruong.Location = new System.Drawing.Point(15, 25);
            this.picHienTruong.Size = new System.Drawing.Size(315, 155);
            this.picHienTruong.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnChonAnh.Location = new System.Drawing.Point(15, 188);
            this.btnChonAnh.Size = new System.Drawing.Size(145, 30);
            this.btnChonAnh.Text = "Đính kèm ảnh hiện trường...";
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);

            this.lblDuongDanAnh.AutoEllipsis = true;
            this.lblDuongDanAnh.Location = new System.Drawing.Point(166, 194);
            this.lblDuongDanAnh.Size = new System.Drawing.Size(164, 20);
            this.lblDuongDanAnh.Text = "Chưa chọn ảnh";

            // DataGridView
            this.dgvAtmStations.AllowUserToAddRows = false;
            this.dgvAtmStations.AllowUserToDeleteRows = false;
            this.dgvAtmStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAtmStations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAtmStations.Location = new System.Drawing.Point(12, 252);
            this.dgvAtmStations.MultiSelect = false;
            this.dgvAtmStations.ReadOnly = true;
            this.dgvAtmStations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAtmStations.Size = new System.Drawing.Size(898, 260);
            this.dgvAtmStations.SelectionChanged += new System.EventHandler(this.dgvAtmStations_SelectionChanged);

            // OpenFileDialog
            this.ofdAnhHienTruong.Filter = "Tệp hình ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|Tất cả tệp (*.*)|*.*";
            this.ofdAnhHienTruong.Title = "Chọn ảnh chụp hiện trường trạm ATM";

            // frmAtmStations
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 524);
            this.Controls.Add(this.dgvAtmStations);
            this.Controls.Add(this.grpAnhHienTruong);
            this.Controls.Add(this.grpThongTin);
            this.Name = "frmAtmStations";
            this.Text = "Quản lý Danh sách Trạm ATM & Tồn quỹ";
            this.Load += new System.EventHandler(this.frmAtmStations_Load);

            this.grpThongTin.ResumeLayout(false);
            this.grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTonQuy)).EndInit();
            this.grpAnhHienTruong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picHienTruong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAtmStations)).EndInit();
            this.ResumeLayout(false);
        }
    }
}