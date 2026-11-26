using _6_7_PowerGridScadaSystem.BUS;
using _6_7_PowerGridScadaSystem.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_7_PowerGridScadaSystem.GUI
{
    public partial class frmPowerGridMonitor : Form
    {
        private readonly SubstationBUS _substationBus = new SubstationBUS();
        private readonly ScadaMonitorBUS _scadaBus = new ScadaMonitorBUS();
        private CancellationTokenSource _cts;

        public frmPowerGridMonitor()
        {
            InitializeComponent();
            ConfigureGridLogsManually();
            _scadaBus.TelemetryReceived += ScadaBus_TelemetryReceived;
        }

        /// <summary>
        /// Cấu hình thủ công các cột của DataGridView dgvGridLogs bằng code.
        /// </summary>
        private void ConfigureGridLogsManually()
        {
            dgvGridLogs.AutoGenerateColumns = false;
            dgvGridLogs.Columns.Clear();

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colChuKy",
                HeaderText = "Chu kỳ",
                FillWeight = 60
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colThoiGian",
                HeaderText = "Thời gian sự cố (HH:mm:ss)",
                FillWeight = 110
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMaTram",
                HeaderText = "Mã trạm",
                FillWeight = 90
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colTenTram",
                HeaderText = "Tên trạm biến áp",
                FillWeight = 140
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDienAp",
                HeaderText = "Điện áp (kV)",
                FillWeight = 85
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colMucTai",
                HeaderText = "Mức mang tải (%)",
                FillWeight = 95
            });

            dgvGridLogs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCanhBao",
                HeaderText = "Mức độ cảnh báo",
                FillWeight = 150
            });
        }

        private void frmPowerGridMonitor_Load(object sender, EventArgs e)
        {
            List<SubstationDTO> stations;
            try
            {
                stations = _substationBus.GetAllSubstations();
            }
            catch
            {
                // Danh sách dự phòng nếu chưa chạy script PowerGridScadaDB.sql trên SQL Server
                stations = new List<SubstationDTO>
                {
                    new SubstationDTO { MaTram = "TBA-110-HD", TenTram = "Trạm 110kV Hà Đông", CapDienApDinhMuc = 110m },
                    new SubstationDTO { MaTram = "TBA-220-CHEM", TenTram = "Trạm 220kV Chèm", CapDienApDinhMuc = 220m },
                    new SubstationDTO { MaTram = "TBA-110-CG", TenTram = "Trạm 110kV Cầu Giấy", CapDienApDinhMuc = 110m }
                };
            }

            cboTramBienAp.DataSource = stations;
            cboTramBienAp.DisplayMember = "TenTram";
            cboTramBienAp.ValueMember = "MaTram";
        }

        private void cboTramBienAp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTramBienAp.SelectedItem is SubstationDTO selected)
            {
                LoadSavedOverloadLogs(selected.MaTram);
            }
        }

        private void LoadSavedOverloadLogs(string maTram)
        {
            dgvGridLogs.Rows.Clear();
            try
            {
                var logs = _substationBus.GetRecentOverloadLogs(maTram);
                foreach (var log in logs)
                {
                    int rowIndex = dgvGridLogs.Rows.Add(
                        log.ChuKyQuet,
                        log.ThoiGianGhiNhan.ToString("HH:mm:ss"),
                        log.MaTram,
                        log.TenTram,
                        $"{log.DienApKV:0.0} kV",
                        $"{log.MucMangTaiPercent}%",
                        log.MucDoCanhBao
                    );
                    dgvGridLogs.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Firebrick;
                }
            }
            catch
            {
                // Bỏ qua nếu chưa kết nối SQL Server
            }
        }

        private async void btnBatDauScada_Click(object sender, EventArgs e)
        {
            if (!(cboTramBienAp.SelectedItem is SubstationDTO selectedStation))
            {
                MessageBox.Show("Vui lòng chọn trạm biến áp cần giám sát.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnBatDauScada.Enabled = false;
            cboTramBienAp.Enabled = false;
            btnNgatKetNoi.Enabled = true;

            lblScadaStatus.Text = $"SCADA Telemetry: Đang thu thập dữ liệu trực tuyến [{selectedStation.TenTram}]...";
            lblScadaStatus.ForeColor = Color.DarkGreen;

            _cts = new CancellationTokenSource();

            try
            {
                await _scadaBus.StartMonitoringLoopAsync(selectedStation, _cts.Token);
            }
            catch (OperationCanceledException)
            {
                // Dừng vòng lặp an toàn khi nhấn Ngắt Kết nối
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi luồng thu thập SCADA:\n" + ex.Message, "Lỗi hệ thống",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    btnBatDauScada.Enabled = true;
                    cboTramBienAp.Enabled = true;
                    btnNgatKetNoi.Enabled = false;
                    lblScadaStatus.Text = "SCADA Telemetry: Đã ngắt kết nối";
                    lblScadaStatus.ForeColor = Color.DimGray;
                }

                if (_cts != null)
                {
                    _cts.Dispose();
                    _cts = null;
                }
            }
        }

        private void btnNgatKetNoi_Click(object sender, EventArgs e)
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                btnNgatKetNoi.Enabled = false;
                lblScadaStatus.Text = "SCADA Telemetry: Đang gửi lệnh ngắt kết nối...";
                _cts.Cancel();
            }
        }

        /// <summary>
        /// Xử lý gói tin SCADA nhận từ Background Thread.
        /// Bắt buộc kiểm tra InvokeRequired và dùng this.Invoke để chuyển về Main UI Thread.
        /// </summary>
        private void ScadaBus_TelemetryReceived(TelemetryDataDTO data)
        {
            if (this.IsDisposed) return;

            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() =>
                {
                    if (this.IsDisposed) return;

                    // 1. Cập nhật thông số điện áp và mức mang tải
                    lblVoltage.Text = $"{data.DienApKV:0.0} kV";
                    lblLoadPercent.Text = $"{data.MucMangTaiPercent}%";

                    // 2. Đổi màu cảnh báo theo ngưỡng an toàn (> 85%)
                    if (data.IsOverload)
                    {
                        lblLoadPercent.ForeColor = Color.Firebrick;
                        lblCanhBaoTrangThai.ForeColor = Color.Firebrick;
                        lblCanhBaoTrangThai.Text = "CẢNH BÁO: TRẠM BIẾN ÁP ĐANG QUÁ TẢI (> 85%)!";

                        // 3. Ghi nhận mốc thời gian quá tải vào DataGridView
                        int rowIndex = dgvGridLogs.Rows.Add(
                            data.ChuKyQuet,
                            data.ThoiGianNhan.ToString("HH:mm:ss"),
                            data.MaTram,
                            data.TenTram,
                            $"{data.DienApKV:0.0} kV",
                            $"{data.MucMangTaiPercent}%",
                            data.MucMangTaiPercent >= 95 ? "QUÁ TẢI NGHIÊM TRỌNG" : "CẢNH BÁO QUÁ TẢI (> 85%)"
                        );

                        dgvGridLogs.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Firebrick;
                        dgvGridLogs.FirstDisplayedScrollingRowIndex = rowIndex;
                    }
                    else
                    {
                        lblLoadPercent.ForeColor = Color.ForestGreen;
                        lblCanhBaoTrangThai.ForeColor = Color.ForestGreen;
                        lblCanhBaoTrangThai.Text = "Trạng thái: Vận hành ổn định (An toàn)";
                    }

                    // 4. Cập nhật StatusStrip (thời gian gói tin cuối & tổng số chu kỳ quét)
                    lblLastPacketTime.Text = $"Gói tin cuối: {data.ThoiGianNhan:HH:mm:ss}";
                    lblTotalCycles.Text = $"Tổng số chu kỳ đã quét: {data.ChuKyQuet}";
                }));
            }
        }

        private void frmPowerGridMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _scadaBus.TelemetryReceived -= ScadaBus_TelemetryReceived;
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }
        }
    }
}