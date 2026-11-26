namespace _6_6_BankAtmMdiSystem.GUI
{
    partial class frmAtmReconciliation
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblNgayDoiSoat;
        private System.Windows.Forms.DateTimePicker dtpNgayDoiSoat;
        private System.Windows.Forms.Button btnChayDoiSoat;
        private System.Windows.Forms.Button btnDungDoiSoat;
        private System.Windows.Forms.Label lblTrangThaiTacVu;

        private System.Windows.Forms.GroupBox grpNhatKy;
        private System.Windows.Forms.ListBox lstNhatKy;

        private System.Windows.Forms.GroupBox grpSaiLech;
        private System.Windows.Forms.DataGridView dgvGiaoDichSaiLech;

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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblNgayDoiSoat = new System.Windows.Forms.Label();
            this.dtpNgayDoiSoat = new System.Windows.Forms.DateTimePicker();
            this.btnChayDoiSoat = new System.Windows.Forms.Button();
            this.btnDungDoiSoat = new System.Windows.Forms.Button();
            this.lblTrangThaiTacVu = new System.Windows.Forms.Label();

            this.grpNhatKy = new System.Windows.Forms.GroupBox();
            this.lstNhatKy = new System.Windows.Forms.ListBox();

            this.grpSaiLech = new System.Windows.Forms.GroupBox();
            this.dgvGiaoDichSaiLech = new System.Windows.Forms.DataGridView();

            this.pnlTop.SuspendLayout();
            this.grpNhatKy.SuspendLayout();
            this.grpSaiLech.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDichSaiLech)).BeginInit();
            this.SuspendLayout();

            // Panel điều khiển trên cùng
            this.pnlTop.Controls.Add(this.lblNgayDoiSoat);
            this.pnlTop.Controls.Add(this.dtpNgayDoiSoat);
            this.pnlTop.Controls.Add(this.btnChayDoiSoat);
            this.pnlTop.Controls.Add(this.btnDungDoiSoat);
            this.pnlTop.Controls.Add(this.lblTrangThaiTacVu);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Size = new System.Drawing.Size(880, 95);

            this.lblNgayDoiSoat.AutoSize = true;
            this.lblNgayDoiSoat.Location = new System.Drawing.Point(15, 22);
            this.lblNgayDoiSoat.Text = "Ngày sao kê đối soát:";

            this.dtpNgayDoiSoat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayDoiSoat.Location = new System.Drawing.Point(150, 18);
            this.dtpNgayDoiSoat.Size = new System.Drawing.Size(140, 23);

            this.btnChayDoiSoat.BackColor = System.Drawing.Color.SeaGreen;
            this.btnChayDoiSoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChayDoiSoat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnChayDoiSoat.ForeColor = System.Drawing.Color.White;
            this.btnChayDoiSoat.Location = new System.Drawing.Point(310, 14);
            this.btnChayDoiSoat.Size = new System.Drawing.Size(185, 34);
            this.btnChayDoiSoat.Text = "Chạy Đối Soát Tự Động";
            this.btnChayDoiSoat.UseVisualStyleBackColor = false;
            this.btnChayDoiSoat.Click += new System.EventHandler(this.btnChayDoiSoat_Click);

            this.btnDungDoiSoat.BackColor = System.Drawing.Color.Firebrick;
            this.btnDungDoiSoat.Enabled = false;
            this.btnDungDoiSoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDungDoiSoat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDungDoiSoat.ForeColor = System.Drawing.Color.White;
            this.btnDungDoiSoat.Location = new System.Drawing.Point(508, 14);
            this.btnDungDoiSoat.Size = new System.Drawing.Size(145, 34);
            this.btnDungDoiSoat.Text = "Dừng Đối Soát";
            this.btnDungDoiSoat.UseVisualStyleBackColor = false;
            this.btnDungDoiSoat.Click += new System.EventHandler(this.btnDungDoiSoat_Click);

            this.lblTrangThaiTacVu.AutoSize = true;
            this.lblTrangThaiTacVu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblTrangThaiTacVu.ForeColor = System.Drawing.Color.Navy;
            this.lblTrangThaiTacVu.Location = new System.Drawing.Point(15, 62);
            this.lblTrangThaiTacVu.Text = "Trạng thái: Sẵn sàng thực hiện đối soát giao dịch cuối ngày.";

            // GroupBox Nhật ký đối soát
            this.grpNhatKy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpNhatKy.Controls.Add(this.lstNhatKy);
            this.grpNhatKy.Location = new System.Drawing.Point(15, 100);
            this.grpNhatKy.Size = new System.Drawing.Size(850, 165);
            this.grpNhatKy.TabStop = false;
            this.grpNhatKy.Text = "Nhật ký xử lý bất đồng bộ (Background Worker Log)";

            this.lstNhatKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstNhatKy.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.lstNhatKy.FormattingEnabled = true;

            // GroupBox Giao dịch sai lệch phát hiện
            this.grpSaiLech.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSaiLech.Controls.Add(this.dgvGiaoDichSaiLech);
            this.grpSaiLech.Location = new System.Drawing.Point(15, 275);
            this.grpSaiLech.Size = new System.Drawing.Size(850, 215);
            this.grpSaiLech.TabStop = false;
            this.grpSaiLech.Text = "Danh sách giao dịch chênh lệch cần tra soát";

            this.dgvGiaoDichSaiLech.AllowUserToAddRows = false;
            this.dgvGiaoDichSaiLech.AllowUserToDeleteRows = false;
            this.dgvGiaoDichSaiLech.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGiaoDichSaiLech.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGiaoDichSaiLech.ReadOnly = true;

            // frmAtmReconciliation
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 502);
            this.Controls.Add(this.grpSaiLech);
            this.Controls.Add(this.grpNhatKy);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmAtmReconciliation";
            this.Text = "Đối soát Sao kê Giao dịch ATM Cuối ngày (Async/Await)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAtmReconciliation_FormClosing);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.grpNhatKy.ResumeLayout(false);
            this.grpSaiLech.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaoDichSaiLech)).EndInit();
            this.ResumeLayout(false);
        }
    }
}