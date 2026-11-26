using System;
using System.Drawing;
using System.Windows.Forms;

namespace _6_6_BankAtmMdiSystem.GUI
{
    public partial class frmBankAtmMain : Form
    {
        private bool _isLocked = false;

        public frmBankAtmMain()
        {
            InitializeComponent();
        }

        private void OpenOrActivateChildForm<T>(Func<T> factory) where T : Form
        {
            foreach (Form child in this.MdiChildren)
            {
                if (child is T)
                {
                    if (child.WindowState == FormWindowState.Minimized)
                    {
                        child.WindowState = FormWindowState.Normal;
                    }
                    child.Activate();
                    return;
                }
            }

            T newForm = factory();
            newForm.MdiParent = this;
            newForm.Show();
        }

        public void UpdateCoreBankingProgress(int percent, string statusText, bool isError = false)
        {
            if (this.IsDisposed) return;

            int clamped = Math.Max(0, Math.Min(100, percent));
            prgTienTrinh.Value = clamped;
            lblPhanTram.Text = $"{clamped}%";

            if (!string.IsNullOrWhiteSpace(statusText))
            {
                lblCoreBanking.Text = statusText;
                lblCoreBanking.ForeColor = isError ? Color.Firebrick : Color.DarkGreen;
            }
        }

        private void mnuDanhSachTram_Click(object sender, EventArgs e)
        {
            OpenOrActivateChildForm(() => new frmAtmStations());
        }

        private void mnuDoiSoatCuoiNgay_Click(object sender, EventArgs e)
        {
            OpenOrActivateChildForm(() => new frmAtmReconciliation());
        }

        private void mnuXepTang_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuXepNgang_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuXepDoc_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuDongTatCa_Click(object sender, EventArgs e)
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
            }
        }

        private void mnuKhoaManHinh_Click(object sender, EventArgs e)
        {
            _isLocked = !_isLocked;
            mnuQuanLyAtm.Enabled = !_isLocked;
            mnuCuaSo.Enabled = !_isLocked;
            mnuDangXuat.Enabled = !_isLocked;

            foreach (Form child in this.MdiChildren)
            {
                child.Enabled = !_isLocked;
            }

            if (_isLocked)
            {
                mnuKhoaManHinh.Text = "Mở khóa màn hình";
                lblCoreBanking.Text = "Core Banking: Phiên làm việc đang bị KHÓA";
                lblCoreBanking.ForeColor = Color.DarkOrange;
            }
            else
            {
                mnuKhoaManHinh.Text = "Khóa màn hình";
                lblCoreBanking.Text = "Core Banking: Đã kết nối (Sẵn sàng)";
                lblCoreBanking.ForeColor = Color.DarkGreen;
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất phiên làm việc hiện tại?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                mnuDongTatCa_Click(sender, e);
                lblGiaoDichVien.Text = "Giao dịch viên trực: [Chưa đăng nhập]";
                lblCoreBanking.Text = "Core Banking: Đã ngắt kết nối";
                lblCoreBanking.ForeColor = Color.Gray;
                prgTienTrinh.Value = 0;
                lblPhanTram.Text = "0%";
                MessageBox.Show("Đã đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblGiaoDichVien.Text = "Giao dịch viên trực: Nguyễn Minh Quân (GDV01)";
                lblCoreBanking.Text = "Core Banking: Đã kết nối (Sẵn sàng)";
                lblCoreBanking.ForeColor = Color.DarkGreen;
            }
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}