namespace _6_7_PowerGridScadaSystem.GUI
{
    partial class frmPowerGridMonitor
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.GroupBox grpDieuKhien;
        private System.Windows.Forms.Label lblChonTram;
        private System.Windows.Forms.ComboBox cboTramBienAp;
        private System.Windows.Forms.Button btnBatDauScada;
        private System.Windows.Forms.Button btnNgatKetNoi;

        private System.Windows.Forms.GroupBox grpDashboard;
        private System.Windows.Forms.Panel pnlDienAp;
        private System.Windows.Forms.Label lblTitleVoltage;
        private System.Windows.Forms.Label lblVoltage;

        private System.Windows.Forms.Panel pnlMucTai;
        private System.Windows.Forms.Label lblTitleLoad;
        private System.Windows.Forms.Label lblLoadPercent;
        private System.Windows.Forms.Label lblCanhBaoTrangThai;

        private System.Windows.Forms.GroupBox grpNhatKySuCo;
        private System.Windows.Forms.DataGridView dgvGridLogs;

        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripStatusLabel lblScadaStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblLastPacketTime;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalCycles;

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
            this.grpDieuKhien = new System.Windows.Forms.GroupBox();
            this.lblChonTram = new System.Windows.Forms.Label();
            this.cboTramBienAp = new System.Windows.Forms.ComboBox();
            this.btnBatDauScada = new System.Windows.Forms.Button();
            this.btnNgatKetNoi = new System.Windows.Forms.Button();

            this.grpDashboard = new System.Windows.Forms.GroupBox();
            this.pnlDienAp = new System.Windows.Forms.Panel();
            this.lblTitleVoltage = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();

            this.pnlMucTai = new System.Windows.Forms.Panel();
            this.lblTitleLoad = new System.Windows.Forms.Label();
            this.lblLoadPercent = new System.Windows.Forms.Label();
            this.lblCanhBaoTrangThai = new System.Windows.Forms.Label();

            this.grpNhatKySuCo = new System.Windows.Forms.GroupBox();
            this.dgvGridLogs = new System.Windows.Forms.DataGridView();

            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.lblScadaStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblLastPacketTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalCycles = new System.Windows.Forms.ToolStripStatusLabel();

            this.grpDieuKhien.SuspendLayout();
            this.grpDashboard.SuspendLayout();
            this.pnlDienAp.SuspendLayout();
            this.pnlMucTai.SuspendLayout();
            this.grpNhatKySuCo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGridLogs)).BeginInit();
            this.stsMain.SuspendLayout();
            this.SuspendLayout();

            // 1. Khu vực điều khiển
            this.grpDieuKhien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDieuKhien.Controls.Add(this.lblChonTram);
            this.grpDieuKhien.Controls.Add(this.cboTramBienAp);
            this.grpDieuKhien.Controls.Add(this.btnBatDauScada);
            this.grpDieuKhien.Controls.Add(this.btnNgatKetNoi);
            this.grpDieuKhien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDieuKhien.Location = new System.Drawing.Point(14, 12);
            this.grpDieuKhien.Size = new System.Drawing.Size(932, 76);
            this.grpDieuKhien.TabStop = false;
            this.grpDieuKhien.Text = "Khu vực Điều khiển Kết nối SCADA";

            this.lblChonTram.AutoSize = true;
            this.lblChonTram.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblChonTram.Location = new System.Drawing.Point(16, 33);
            this.lblChonTram.Text = "Chọn Trạm biến áp:";

            this.cboTramBienAp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTramBienAp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTramBienAp.Location = new System.Drawing.Point(155, 29);
            this.cboTramBienAp.Size = new System.Drawing.Size(310, 25);
            this.cboTramBienAp.SelectedIndexChanged += new System.EventHandler(this.cboTramBienAp_SelectedIndexChanged);

            this.btnBatDauScada.BackColor = System.Drawing.Color.SeaGreen;
            this.btnBatDauScada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatDauScada.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnBatDauScada.ForeColor = System.Drawing.Color.White;
            this.btnBatDauScada.Location = new System.Drawing.Point(490, 24);
            this.btnBatDauScada.Size = new System.Drawing.Size(215, 36);
            this.btnBatDauScada.Text = "Bắt đầu Giám sát SCADA";
            this.btnBatDauScada.UseVisualStyleBackColor = false;
            this.btnBatDauScada.Click += new System.EventHandler(this.btnBatDauScada_Click);

            this.btnNgatKetNoi.BackColor = System.Drawing.Color.Firebrick;
            this.btnNgatKetNoi.Enabled = false;
            this.btnNgatKetNoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNgatKetNoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNgatKetNoi.ForeColor = System.Drawing.Color.White;
            this.btnNgatKetNoi.Location = new System.Drawing.Point(720, 24);
            this.btnNgatKetNoi.Size = new System.Drawing.Size(185, 36);
            this.btnNgatKetNoi.Text = "Ngắt Kết nối";
            this.btnNgatKetNoi.UseVisualStyleBackColor = false;
            this.btnNgatKetNoi.Click += new System.EventHandler(this.btnNgatKetNoi_Click);

            // 2. Khu vực bảng thông số trực quan (Real-time Dashboard)
            this.grpDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDashboard.Controls.Add(this.pnlDienAp);
            this.grpDashboard.Controls.Add(this.pnlMucTai);
            this.grpDashboard.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpDashboard.Location = new System.Drawing.Point(14, 98);
            this.grpDashboard.Size = new System.Drawing.Size(932, 165);
            this.grpDashboard.TabStop = false;
            this.grpDashboard.Text = "Bảng Thông số Vận hành Thời gian thực (Real-time Dashboard)";

            // Panel Điện áp
            this.pnlDienAp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlDienAp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDienAp.Controls.Add(this.lblTitleVoltage);
            this.pnlDienAp.Controls.Add(this.lblVoltage);
            this.pnlDienAp.Location = new System.Drawing.Point(18, 28);
            this.pnlDienAp.Size = new System.Drawing.Size(435, 120);

            this.lblTitleVoltage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleVoltage.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleVoltage.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitleVoltage.Height = 32;
            this.lblTitleVoltage.Text = "ĐIỆN ÁP THANH CÁI HIỆN TẠI (kV)";
            this.lblTitleVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblVoltage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVoltage.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblVoltage.ForeColor = System.Drawing.Color.Navy;
            this.lblVoltage.Text = "--- kV";
            this.lblVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Panel Mức mang tải
            this.pnlMucTai.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMucTai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMucTai.Controls.Add(this.lblLoadPercent);
            this.pnlMucTai.Controls.Add(this.lblCanhBaoTrangThai);
            this.pnlMucTai.Controls.Add(this.lblTitleLoad);
            this.pnlMucTai.Location = new System.Drawing.Point(475, 28);
            this.pnlMucTai.Size = new System.Drawing.Size(438, 120);

            this.lblTitleLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleLoad.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleLoad.ForeColor = System.Drawing.Color.DimGray;
            this.lblTitleLoad.Height = 32;
            this.lblTitleLoad.Text = "MỨC MANG TẢI MÁY BIẾN ÁP (%)";
            this.lblTitleLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblLoadPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoadPercent.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblLoadPercent.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblLoadPercent.Text = "--- %";
            this.lblLoadPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblCanhBaoTrangThai.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblCanhBaoTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCanhBaoTrangThai.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblCanhBaoTrangThai.Height = 26;
            this.lblCanhBaoTrangThai.Text = "Trạng thái: Chờ tín hiệu đo lường";
            this.lblCanhBaoTrangThai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 3. Khu vực nhật ký sự cố (DataGridView cấu hình thủ công bằng code)
            this.grpNhatKySuCo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNhatKySuCo.Controls.Add(this.dgvGridLogs);
            this.grpNhatKySuCo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.grpNhatKySuCo.Location = new System.Drawing.Point(14, 273);
            this.grpNhatKySuCo.Size = new System.Drawing.Size(932, 265);
            this.grpNhatKySuCo.TabStop = false;
            this.grpNhatKySuCo.Text = "Nhật ký Sự cố Quá tải Lưới điện (Ngưỡng cảnh báo > 85%)";

            this.dgvGridLogs.AllowUserToAddRows = false;
            this.dgvGridLogs.AllowUserToDeleteRows = false;
            this.dgvGridLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGridLogs.BackgroundColor = System.Drawing.Color.White;
            this.dgvGridLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGridLogs.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dgvGridLogs.ReadOnly = true;
            this.dgvGridLogs.RowHeadersVisible = false;
            this.dgvGridLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            // 4. StatusStrip
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.lblScadaStatus,
                this.lblLastPacketTime,
                this.lblTotalCycles
            });
            this.stsMain.Location = new System.Drawing.Point(0, 550);
            this.stsMain.Size = new System.Drawing.Size(960, 24);

            this.lblScadaStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblScadaStatus.ForeColor = System.Drawing.Color.DimGray;
            this.lblScadaStatus.Spring = true;
            this.lblScadaStatus.Text = "SCADA Telemetry: Chưa kết nối";
            this.lblScadaStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblLastPacketTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lblLastPacketTime.Text = "Gói tin cuối: --:--:--";

            this.lblTotalCycles.Text = "Tổng số chu kỳ đã quét: 0";

            // frmPowerGridMonitor
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 574);
            this.Controls.Add(this.grpNhatKySuCo);
            this.Controls.Add(this.grpDashboard);
            this.Controls.Add(this.grpDieuKhien);
            this.Controls.Add(this.stsMain);
            this.Name = "frmPowerGridMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRUNG TÂM ĐIỀU ĐỘ & GIÁM SÁT LƯỚI ĐIỆN THỜI GIAN THỰC (SCADA)";
            this.Load += new System.EventHandler(this.frmPowerGridMonitor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPowerGridMonitor_FormClosing);

            this.grpDieuKhien.ResumeLayout(false);
            this.grpDieuKhien.PerformLayout();
            this.grpDashboard.ResumeLayout(false);
            this.pnlDienAp.ResumeLayout(false);
            this.pnlMucTai.ResumeLayout(false);
            this.grpNhatKySuCo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGridLogs)).EndInit();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}