using Microsoft.EntityFrameworkCore;
using Cau2LTTQ.Models;

namespace Cau2LTTQ;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    // =========================================
    // LOAD FORM
    // =========================================
    private async void Form1_Load(
        object sender,
        EventArgs e)
    {
        LoadComboBox();

        await LoadDataAsync();

        ClearInput();
    }

    // =========================================
    // LOAD COMBOBOX
    // =========================================
    private void LoadComboBox()
    {
        // ComboBox nhập hạng thành viên
        cboHangThanhVien.Items.Clear();

        cboHangThanhVien.Items.Add("Basic");
        cboHangThanhVien.Items.Add("VIP");
        cboHangThanhVien.Items.Add("Premium");

        cboHangThanhVien.SelectedIndex = 0;


        // ComboBox tìm kiếm
        cboTimHang.Items.Clear();

        cboTimHang.Items.Add("Basic");
        cboTimHang.Items.Add("VIP");
        cboTimHang.Items.Add("Premium");

        cboTimHang.SelectedIndex = 0;
    }

    // =========================================
    // LOAD DỮ LIỆU
    // =========================================
    private async Task LoadDataAsync()
    {
        try
        {
            using var context =
                new FitZoneContext();

            var danhSach =
                await context.HoiViens
                    .AsNoTracking()
                    .OrderBy(x => x.MaHv)
                    .ToListAsync();

            dgvHoiVien.DataSource = null;

            dgvHoiVien.DataSource =
                danhSach;

            dgvHoiVien.ClearSelection();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể tải dữ liệu từ SQL Server!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================
    // LÀM TRỐNG CONTROL
    // =========================================
    private void ClearInput()
    {
        txtMaHV.Clear();

        txtHoTen.Clear();

        txtSDT.Clear();

        txtEmail.Clear();

        // Giới tính mặc định Nam
        radNam.Checked = true;

        radNu.Checked = false;

        // Mặc định 18 tuổi
        dtpNgaySinh.Value =
            DateTime.Today.AddYears(-18);

        // Basic
        cboHangThanhVien.SelectedIndex = 0;

        // Đang hoạt động
        chkDangHoatDong.Checked = true;

        dgvHoiVien.ClearSelection();

        txtHoTen.Focus();
    }

    // =========================================
    // CLICK DÒNG DATAGRIDVIEW
    // =========================================
    private void dgvHoiVien_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (dgvHoiVien.CurrentRow == null)
            return;

        if (dgvHoiVien.CurrentRow.DataBoundItem
            is not HoiVien hoiVien)
        {
            return;
        }

        // Mã
        txtMaHV.Text =
            hoiVien.MaHv.ToString();

        // Họ tên
        txtHoTen.Text =
            hoiVien.HoTen;

        // SĐT
        txtSDT.Text =
            hoiVien.Sdt ?? "";

        // Email
        txtEmail.Text =
            hoiVien.Email ?? "";

        // true = Nam
        // false = Nữ
        radNam.Checked =
            hoiVien.GioiTinh;

        radNu.Checked =
            !hoiVien.GioiTinh;

        // Ngày sinh
        dtpNgaySinh.Value =
            hoiVien.NgaySinh;

        // Hạng thành viên
        if (!string.IsNullOrEmpty(
            hoiVien.HangThanhVien))
        {
            cboHangThanhVien.SelectedItem =
                hoiVien.HangThanhVien;
        }

        // Trạng thái
        chkDangHoatDong.Checked =
            hoiVien.TrangThai;
    }

    // =========================================
    // FORMAT DATAGRIDVIEW
    // =========================================
    private void dgvHoiVien_CellFormatting(
        object sender,
        DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0)
            return;

        string propertyName =
            dgvHoiVien.Columns[e.ColumnIndex]
                .DataPropertyName;

        // Giới tính
        if (propertyName == "GioiTinh"
            && e.Value is bool gioiTinh)
        {
            e.Value =
                gioiTinh ? "Nam" : "Nữ";

            e.FormattingApplied = true;
        }

        // Trạng thái
        if (propertyName == "TrangThai"
            && e.Value is bool trangThai)
        {
            e.Value =
                trangThai
                    ? "Đang hoạt động"
                    : "Tạm ngưng";

            e.FormattingApplied = true;
        }

        // Ngày sinh
        if (propertyName == "NgaySinh"
            && e.Value is DateTime ngaySinh)
        {
            e.Value =
                ngaySinh.ToString(
                    "dd/MM/yyyy");

            e.FormattingApplied = true;
        }

        // Ngày đăng ký
        if (propertyName == "NgayDangKy"
            && e.Value is DateTime ngayDangKy)
        {
            e.Value =
                ngayDangKy.ToString(
                    "dd/MM/yyyy HH:mm:ss");

            e.FormattingApplied = true;
        }
    }

    // =========================================
    // VALIDATE
    // =========================================
    private bool ValidateInput()
    {
        // =============================
        // HỌ TÊN
        // =============================
        if (string.IsNullOrWhiteSpace(
            txtHoTen.Text))
        {
            MessageBox.Show(
                "Họ tên không được để trống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtHoTen.Focus();

            return false;
        }

        // =============================
        // SĐT
        // =============================
        string sdt =
            txtSDT.Text.Trim();

        if (string.IsNullOrWhiteSpace(sdt))
        {
            MessageBox.Show(
                "Số điện thoại không được để trống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSDT.Focus();

            return false;
        }

        // Chỉ chứa số
        if (!sdt.All(char.IsDigit))
        {
            MessageBox.Show(
                "Số điện thoại chỉ được chứa chữ số!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSDT.Focus();

            return false;
        }

        // 9 - 11 ký tự
        if (sdt.Length < 9 ||
            sdt.Length > 11)
        {
            MessageBox.Show(
                "Số điện thoại phải có từ 9 đến 11 chữ số!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSDT.Focus();

            return false;
        }

        // =============================
        // EMAIL
        // =============================
        string email =
            txtEmail.Text.Trim();

        if (string.IsNullOrWhiteSpace(email))
        {
            MessageBox.Show(
                "Email không được để trống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtEmail.Focus();

            return false;
        }

        if (!email.Contains('@'))
        {
            MessageBox.Show(
                "Email không hợp lệ! Email phải chứa ký tự @.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtEmail.Focus();

            return false;
        }

        // =============================
        // TUỔI >= 15
        // =============================
        DateTime ngaySinh =
            dtpNgaySinh.Value.Date;

        if (ngaySinh >
            DateTime.Today.AddYears(-15))
        {
            MessageBox.Show(
                "Hội viên phải từ 15 tuổi trở lên!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            dtpNgaySinh.Focus();

            return false;
        }

        // =============================
        // HẠNG THÀNH VIÊN
        // =============================
        if (cboHangThanhVien.SelectedItem == null)
        {
            MessageBox.Show(
                "Vui lòng chọn hạng thành viên!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cboHangThanhVien.Focus();

            return false;
        }

        return true;
    }

    // =========================================
    // THÊM
    // =========================================
    private async void btnThem_Click(
        object sender,
        EventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            using var context =
                new FitZoneContext();

            var hoiVienMoi =
                new HoiVien
                {
                    HoTen =
                        txtHoTen.Text.Trim(),

                    // Nam = true
                    // Nữ = false
                    GioiTinh =
                        radNam.Checked,

                    NgaySinh =
                        dtpNgaySinh.Value.Date,

                    Sdt =
                        txtSDT.Text.Trim(),

                    Email =
                        txtEmail.Text.Trim(),

                    HangThanhVien =
                        cboHangThanhVien
                            .SelectedItem!
                            .ToString(),

                    TrangThai =
                        chkDangHoatDong.Checked
                };

            // EF CORE ADD
            context.HoiViens.Add(
                hoiVienMoi);

            // Lưu xuống SQL Server
            await context.SaveChangesAsync();

            MessageBox.Show(
                "Thêm hội viên thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Load lại bảng
            await LoadDataAsync();

            // Xóa các ô
            ClearInput();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể thêm hội viên!\n\n" +
                (ex.InnerException?.Message
                 ?? ex.Message),
                "Lỗi Database",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Có lỗi xảy ra!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================
    // SỬA
    // =========================================
    private async void btnSua_Click(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            txtMaHV.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn hội viên cần sửa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!ValidateInput())
            return;

        if (!int.TryParse(
            txtMaHV.Text,
            out int maHV))
        {
            MessageBox.Show(
                "Mã hội viên không hợp lệ!",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        try
        {
            using var context =
                new FitZoneContext();

            // Tìm hội viên bằng EF Core
            var hoiVien =
                await context.HoiViens
                    .FirstOrDefaultAsync(
                        x => x.MaHv == maHV);

            if (hoiVien == null)
            {
                MessageBox.Show(
                    "Không tìm thấy hội viên!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Cập nhật dữ liệu
            hoiVien.HoTen =
                txtHoTen.Text.Trim();

            hoiVien.GioiTinh =
                radNam.Checked;

            hoiVien.NgaySinh =
                dtpNgaySinh.Value.Date;

            hoiVien.Sdt =
                txtSDT.Text.Trim();

            hoiVien.Email =
                txtEmail.Text.Trim();

            hoiVien.HangThanhVien =
                cboHangThanhVien
                    .SelectedItem!
                    .ToString();

            hoiVien.TrangThai =
                chkDangHoatDong.Checked;

            // UPDATE SQL Server
            await context.SaveChangesAsync();

            MessageBox.Show(
                "Cập nhật hội viên thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();

            ClearInput();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể cập nhật hội viên!\n\n" +
                (ex.InnerException?.Message
                 ?? ex.Message),
                "Lỗi Database",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Có lỗi xảy ra!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================
    // XÓA
    // =========================================
    private async void btnXoa_Click(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            txtMaHV.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn hội viên cần xóa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!int.TryParse(
            txtMaHV.Text,
            out int maHV))
        {
            return;
        }

        // Xác nhận Yes / No
        DialogResult ketQua =
            MessageBox.Show(
                "Bạn có chắc chắn muốn xóa hội viên:\n\n" +
                txtHoTen.Text +
                " ?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (ketQua != DialogResult.Yes)
            return;

        try
        {
            using var context =
                new FitZoneContext();

            var hoiVien =
                await context.HoiViens
                    .FirstOrDefaultAsync(
                        x => x.MaHv == maHV);

            if (hoiVien == null)
            {
                MessageBox.Show(
                    "Không tìm thấy hội viên cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // DELETE EF Core
            context.HoiViens.Remove(
                hoiVien);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Xóa hội viên thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();

            ClearInput();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể xóa hội viên!\n\n" +
                (ex.InnerException?.Message
                 ?? ex.Message),
                "Lỗi Database",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Có lỗi xảy ra!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================================
    // LÀM MỚI
    // =========================================
    private async void btnLamMoi_Click(
        object sender,
        EventArgs e)
    {
        // Xóa tìm kiếm
        txtTimKiem.Clear();

        cboTimHang.SelectedIndex = 0;

        // Load lại toàn bộ dữ liệu
        await LoadDataAsync();

        ClearInput();
    }

    // =========================================
    // TÌM KIẾM
    // HỌ TÊN + HẠNG THÀNH VIÊN
    // =========================================
    private async void btnTimKiem_Click(
        object sender,
        EventArgs e)
    {
        string tuKhoa =
            txtTimKiem.Text.Trim();

        if (cboTimHang.SelectedItem == null)
        {
            MessageBox.Show(
                "Vui lòng chọn hạng thành viên cần tìm!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        string hangThanhVien =
            cboTimHang
                .SelectedItem
                .ToString()!;

        try
        {
            using var context =
                new FitZoneContext();

            var ketQua =
                await context.HoiViens
                    .AsNoTracking()

                    // =================================
                    // ĐÚNG YÊU CẦU ĐỀ:
                    // WHERE + CONTAINS + &&
                    // =================================
                    .Where(x =>
                        x.HoTen.Contains(tuKhoa)
                        &&
                        x.HangThanhVien ==
                        hangThanhVien)

                    .OrderBy(x => x.MaHv)

                    .ToListAsync();

            dgvHoiVien.DataSource = null;

            dgvHoiVien.DataSource =
                ketQua;

            dgvHoiVien.ClearSelection();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Có lỗi khi tìm kiếm!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}