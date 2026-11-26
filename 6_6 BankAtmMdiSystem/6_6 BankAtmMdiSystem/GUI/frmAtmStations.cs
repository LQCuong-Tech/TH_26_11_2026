using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using _6_6_BankAtmMdiSystem.BUS;
using _6_6_BankAtmMdiSystem.DTO;

namespace _6_6_BankAtmMdiSystem.GUI
{
    public partial class frmAtmStations : Form
    {
        private readonly AtmStationBUS _stationBus = new AtmStationBUS();
        private string _duongDanAnhHienTai = string.Empty;

        public frmAtmStations()
        {
            InitializeComponent();
        }

        private void frmAtmStations_Load(object sender, EventArgs e)
        {
            cboTrangThai.SelectedIndex = 0;
            LoadGridData();
        }

        private void LoadGridData()
        {
            try
            {
                dgvAtmStations.DataSource = null;
                dgvAtmStations.DataSource = _stationBus.GetAllStations();
                ConfigureGridColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách trạm ATM:\n" + ex.Message,
                    "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGridColumns()
        {
            if (dgvAtmStations.Columns["MaTram"] != null)
                dgvAtmStations.Columns["MaTram"].HeaderText = "Mã trạm";

            if (dgvAtmStations.Columns["DiaChi"] != null)
                dgvAtmStations.Columns["DiaChi"].HeaderText = "Địa chỉ đặt máy";

            if (dgvAtmStations.Columns["TonQuy"] != null)
            {
                dgvAtmStations.Columns["TonQuy"].HeaderText = "Tồn quỹ hiện tại (VNĐ)";
                dgvAtmStations.Columns["TonQuy"].DefaultCellStyle.Format = "N0";
                dgvAtmStations.Columns["TonQuy"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvAtmStations.Columns["TrangThai"] != null)
                dgvAtmStations.Columns["TrangThai"].HeaderText = "Trạng thái hoạt động";

            if (dgvAtmStations.Columns["DuongDanAnh"] != null)
                dgvAtmStations.Columns["DuongDanAnh"].HeaderText = "Tệp ảnh hiện trường";
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            if (ofdAnhHienTruong.ShowDialog() == DialogResult.OK)
            {
                _duongDanAnhHienTai = ofdAnhHienTruong.FileName;
                lblDuongDanAnh.Text = Path.GetFileName(_duongDanAnhHienTai);
                LoadPreviewImage(_duongDanAnhHienTai);
            }
        }

        private void LoadPreviewImage(string filePath)
        {
            if (picHienTruong.Image != null)
            {
                picHienTruong.Image.Dispose();
                picHienTruong.Image = null;
            }

            if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    picHienTruong.Image = Image.FromStream(fs);
                }
            }
        }

        private void dgvAtmStations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAtmStations.CurrentRow?.DataBoundItem is AtmStationDTO selected)
            {
                txtMaTram.Text = selected.MaTram;
                txtDiaChi.Text = selected.DiaChi;
                numTonQuy.Value = Math.Min(numTonQuy.Maximum, Math.Max(numTonQuy.Minimum, selected.TonQuy));
                cboTrangThai.SelectedItem = selected.TrangThai;

                _duongDanAnhHienTai = selected.DuongDanAnh ?? string.Empty;
                lblDuongDanAnh.Text = string.IsNullOrWhiteSpace(_duongDanAnhHienTai)
                    ? "Chưa có ảnh"
                    : Path.GetFileName(_duongDanAnhHienTai);

                LoadPreviewImage(_duongDanAnhHienTai);
            }
        }

        private AtmStationDTO GetStationFromInputs()
        {
            return new AtmStationDTO
            {
                MaTram = txtMaTram.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                TonQuy = numTonQuy.Value,
                TrangThai = cboTrangThai.SelectedItem?.ToString() ?? "Hoạt động bình thường",
                DuongDanAnh = _duongDanAnhHienTai
            };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                _stationBus.AddStation(GetStationFromInputs());
                LoadGridData();
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!(dgvAtmStations.CurrentRow?.DataBoundItem is AtmStationDTO selected)) return;

            try
            {
                _stationBus.UpdateStation(GetStationFromInputs(), selected.MaTram);
                LoadGridData();
                MessageBox.Show("Đã cập nhật thông tin trạm ATM.", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!(dgvAtmStations.CurrentRow?.DataBoundItem is AtmStationDTO selected)) return;

            try
            {
                _stationBus.DeleteStation(selected.MaTram);
                LoadGridData();
                ClearInputs();
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                MessageBox.Show("Không thể xóa trạm ATM này vì đã có dữ liệu giao dịch đối soát liên quan.",
                    "Ràng buộc khóa ngoại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtMaTram.Clear();
            txtDiaChi.Clear();
            numTonQuy.Value = 0;
            cboTrangThai.SelectedIndex = 0;
            _duongDanAnhHienTai = string.Empty;
            lblDuongDanAnh.Text = "Chưa chọn ảnh";
            LoadPreviewImage(null);
            txtMaTram.Focus();
        }
    }
}