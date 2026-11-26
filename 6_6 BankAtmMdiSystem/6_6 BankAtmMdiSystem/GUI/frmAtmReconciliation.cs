using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using _6_6_BankAtmMdiSystem.BUS;
using _6_6_BankAtmMdiSystem.DTO;

namespace _6_6_BankAtmMdiSystem.GUI
{
    public partial class frmAtmReconciliation : Form
    {
        private readonly AtmReconciliationBUS _reconciliationBus = new AtmReconciliationBUS();
        private CancellationTokenSource _cts;

        public frmAtmReconciliation()
        {
            InitializeComponent();
        }

        private void AppendLog(string message)
        {
            lstNhatKy.Items.Add($"[{DateTime.Now:HH:mm:ss}] {message}");
            lstNhatKy.TopIndex = lstNhatKy.Items.Count - 1;
        }

        private void UpdateParentStatus(int percent, string statusText, bool isError = false)
        {
            if (this.MdiParent is frmBankAtmMain mainForm)
            {
                mainForm.UpdateCoreBankingProgress(percent, statusText, isError);
            }
        }

        private void ConfigureGridColumns()
        {
            if (dgvGiaoDichSaiLech.Columns["MaGiaoDich"] != null)
                dgvGiaoDichSaiLech.Columns["MaGiaoDich"].HeaderText = "Mã Giao Dịch";

            if (dgvGiaoDichSaiLech.Columns["MaTram"] != null)
                dgvGiaoDichSaiLech.Columns["MaTram"].HeaderText = "Mã Trạm ATM";

            if (dgvGiaoDichSaiLech.Columns["NgayGiaoDich"] != null)
            {
                dgvGiaoDichSaiLech.Columns["NgayGiaoDich"].HeaderText = "Ngày Giao Dịch";
                dgvGiaoDichSaiLech.Columns["NgayGiaoDich"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvGiaoDichSaiLech.Columns["LoaiGiaoDich"] != null)
                dgvGiaoDichSaiLech.Columns["LoaiGiaoDich"].HeaderText = "Loại Giao Dịch";

            if (dgvGiaoDichSaiLech.Columns["SoTienCoreBanking"] != null)
            {
                dgvGiaoDichSaiLech.Columns["SoTienCoreBanking"].HeaderText = "Core Banking (VNĐ)";
                dgvGiaoDichSaiLech.Columns["SoTienCoreBanking"].DefaultCellStyle.Format = "N0";
            }

            if (dgvGiaoDichSaiLech.Columns["SoTienAtmLog"] != null)
            {
                dgvGiaoDichSaiLech.Columns["SoTienAtmLog"].HeaderText = "Nhật ký ATM (VNĐ)";
                dgvGiaoDichSaiLech.Columns["SoTienAtmLog"].DefaultCellStyle.Format = "N0";
            }

            if (dgvGiaoDichSaiLech.Columns["KetLuan"] != null)
                dgvGiaoDichSaiLech.Columns["KetLuan"].HeaderText = "Kết luận";
        }

        private async void btnChayDoiSoat_Click(object sender, EventArgs e)
        {
            btnChayDoiSoat.Enabled = false;
            btnDungDoiSoat.Enabled = true;
            lstNhatKy.Items.Clear();
            dgvGiaoDichSaiLech.DataSource = null;

            DateTime ngayDoiSoat = dtpNgayDoiSoat.Value.Date;
            _cts = new CancellationTokenSource();

            IProgress<ReconciliationProgressDTO> progressReporter = new Progress<ReconciliationProgressDTO>(report =>
            {
                lblTrangThaiTacVu.Text = $"Trạng thái: {report.StepMessage}";
                AppendLog(report.StepMessage);
                UpdateParentStatus(report.Percent, $"Core Banking: {report.StepMessage}");
            });

            try
            {
                UpdateParentStatus(0, "Core Banking: Bắt đầu phiên đối soát cuối ngày...");

                List<AtmTransactionDTO> ketQuaSaiLech = await _reconciliationBus.RunReconciliationAsync(
                    ngayDoiSoat,
                    progressReporter,
                    _cts.Token);

                dgvGiaoDichSaiLech.DataSource = ketQuaSaiLech;
                ConfigureGridColumns();

                UpdateParentStatus(100, "Core Banking: Đối soát hoàn tất (Đã sẵn sàng)");
                MessageBox.Show(
                    $"Đã đối soát xong dữ liệu ngày {ngayDoiSoat:dd/MM/yyyy}.\nPhát hiện {ketQuaSaiLech.Count} giao dịch cần tra soát.",
                    "Hoàn tất đối soát",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (OperationCanceledException)
            {
                lblTrangThaiTacVu.Text = "Trạng thái: Đã hủy tiến trình đối soát theo yêu cầu người dùng.";
                AppendLog(">>> CẢNH BÁO: Tiến trình đối soát đã bị DỪNG ĐỘT NGỘT bởi Giao dịch viên.");
                UpdateParentStatus(0, "Core Banking: Đã hủy đối soát (Sẵn sàng)", isError: true);
            }
            catch (Exception ex)
            {
                lblTrangThaiTacVu.Text = "Trạng thái: Lỗi hệ thống khi đối soát.";
                AppendLog($"LỖI: {ex.Message}");
                UpdateParentStatus(0, "Core Banking: Lỗi kết nối đối soát", isError: true);
            }
            finally
            {
                btnChayDoiSoat.Enabled = true;
                btnDungDoiSoat.Enabled = false;
                if (_cts != null)
                {
                    _cts.Dispose();
                    _cts = null;
                }
            }
        }

        private void btnDungDoiSoat_Click(object sender, EventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                btnDungDoiSoat.Enabled = false;
                AppendLog("Đang gửi tín hiệu hủy (CancellationToken) tới tiến trình nền...");
                _cts.Cancel();
            }
        }

        private void frmAtmReconciliation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }
        }
    }
}