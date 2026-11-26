namespace _6_6_BankAtmMdiSystem.GUI
{
    partial class frmBankAtmMain
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangXuat;
        private System.Windows.Forms.ToolStripMenuItem mnuKhoaManHinh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;

        private System.Windows.Forms.ToolStripMenuItem mnuQuanLyAtm;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhSachTram;
        private System.Windows.Forms.ToolStripMenuItem mnuDoiSoatCuoiNgay;

        private System.Windows.Forms.ToolStripMenuItem mnuCuaSo;
        private System.Windows.Forms.ToolStripMenuItem mnuXepTang;
        private System.Windows.Forms.ToolStripMenuItem mnuXepNgang;
        private System.Windows.Forms.ToolStripMenuItem mnuXepDoc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuDongTatCa;

        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel lblGiaoDichVien;
        private System.Windows.Forms.ToolStripStatusLabel lblCoreBanking;
        private System.Windows.Forms.ToolStripProgressBar prgTienTrinh;
        private System.Windows.Forms.ToolStripStatusLabel lblPhanTram;

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
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKhoaManHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();

            this.mnuQuanLyAtm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhSachTram = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiSoatCuoiNgay = new System.Windows.Forms.ToolStripMenuItem();

            this.mnuCuaSo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXepTang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXepNgang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuXepDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDongTatCa = new System.Windows.Forms.ToolStripMenuItem();

            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.lblGiaoDichVien = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCoreBanking = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgTienTrinh = new System.Windows.Forms.ToolStripProgressBar();
            this.lblPhanTram = new System.Windows.Forms.ToolStripStatusLabel();

            this.mnuMain.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.SuspendLayout();

            // MenuStrip
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuHeThong,
                this.mnuQuanLyAtm,
                this.mnuCuaSo
            });
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1184, 28);

            // Hệ thống
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuDangXuat,
                this.mnuKhoaManHinh,
                this.toolStripSeparator1,
                this.mnuThoat
            });
            this.mnuHeThong.Text = "&Hệ thống";

            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);

            this.mnuKhoaManHinh.Text = "Khóa màn hình";
            this.mnuKhoaManHinh.Click += new System.EventHandler(this.mnuKhoaManHinh_Click);

            this.mnuThoat.Text = "Thoát";
            this.mnuThoat.Click += new System.EventHandler(this.mnuThoat_Click);

            // Quản lý ATM
            this.mnuQuanLyAtm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuDanhSachTram,
                this.mnuDoiSoatCuoiNgay
            });
            this.mnuQuanLyAtm.Text = "&Quản lý ATM";

            this.mnuDanhSachTram.Text = "Danh sách Trạm ATM && Tồn quỹ";
            this.mnuDanhSachTram.Click += new System.EventHandler(this.mnuDanhSachTram_Click);

            this.mnuDoiSoatCuoiNgay.Text = "Đối soát Giao dịch Cuối ngày";
            this.mnuDoiSoatCuoiNgay.Click += new System.EventHandler(this.mnuDoiSoatCuoiNgay_Click);

            // Cửa sổ
            this.mnuCuaSo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.mnuXepTang,
                this.mnuXepNgang,
                this.mnuXepDoc,
                this.toolStripSeparator2,
                this.mnuDongTatCa
            });
            this.mnuCuaSo.Text = "&Cửa sổ";

            this.mnuXepTang.Text = "Xếp tầng (Cascade)";
            this.mnuXepTang.Click += new System.EventHandler(this.mnuXepTang_Click);

            this.mnuXepNgang.Text = "Xếp ngang (Tile Horizontal)";
            this.mnuXepNgang.Click += new System.EventHandler(this.mnuXepNgang_Click);

            this.mnuXepDoc.Text = "Xếp dọc (Tile Vertical)";
            this.mnuXepDoc.Click += new System.EventHandler(this.mnuXepDoc_Click);

            this.mnuDongTatCa.Text = "Đóng tất cả";
            this.mnuDongTatCa.Click += new System.EventHandler(this.mnuDongTatCa_Click);

            // StatusStrip
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblGiaoDichVien,
                this.lblCoreBanking,
                this.prgTienTrinh,
                this.lblPhanTram
            });
            this.stsMain.Location = new System.Drawing.Point(0, 637);
            this.stsMain.Size = new System.Drawing.Size(1184, 24);

            this.lblGiaoDichVien.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblGiaoDichVien.Text = "Giao dịch viên trực: Nguyễn Minh Quân (GDV01)";

            this.lblCoreBanking.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblCoreBanking.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblCoreBanking.Spring = true;
            this.lblCoreBanking.Text = "Core Banking: Đã kết nối (Sẵn sàng)";
            this.lblCoreBanking.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.prgTienTrinh.Size = new System.Drawing.Size(220, 18);
            this.prgTienTrinh.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

            this.lblPhanTram.Text = "0%";

            // frmBankAtmMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.mnuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmBankAtmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG ĐIỀU HÀNH MẠNG LƯỚI CÂY ATM NGÂN HÀNG (MDI)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}