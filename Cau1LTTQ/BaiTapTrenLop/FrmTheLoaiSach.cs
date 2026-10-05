using Microsoft.EntityFrameworkCore;
using QuanLyTheLoaiSach.Models;

namespace QuanLyTheLoaiSach;

public partial class FrmTheLoaiSach : Form
{
    public FrmTheLoaiSach()
    {
        InitializeComponent();
    }

    // =========================
    // LOAD FORM
    // =========================
    private async void FrmTheLoaiSach_Load(
        object sender,
        EventArgs e)
    {
        await LoadDataAsync();
        ClearInput();
    }

    // =========================
    // LOAD DATAGRIDVIEW
    // =========================
    private async Task LoadDataAsync()
    {
        try
        {
            using var context = new TriThucBooksContext();

            var danhSach = await context.TheLoaiSaches
                .AsNoTracking()
                .OrderBy(x => x.MaTl)
                .ToListAsync();

            dgvTheLoaiSach.DataSource = danhSach;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể tải dữ liệu.\n\n" + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================
    // CLEAR INPUT
    // =========================
    private void ClearInput()
    {
        txtMaTL.Clear();
        txtTenTheLoai.Clear();
        txtMoTa.Clear();

        lblNgayTao.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"); 

        dgvTheLoaiSach.ClearSelection();

        txtTenTheLoai.Focus();
    }

    // =========================
    // SELECTION CHANGED
    // =========================
    private void dgvTheLoaiSach_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (dgvTheLoaiSach.CurrentRow == null)
            return;

        if (dgvTheLoaiSach.CurrentRow.DataBoundItem
            is not TheLoaiSach theLoai)
        {
            return;
        }

        txtMaTL.Text = theLoai.MaTl.ToString();

        txtTenTheLoai.Text =
            theLoai.TenTheLoai;

        txtMoTa.Text =
            theLoai.MoTa ?? "";

        lblNgayTao.Text =
            theLoai.NgayTao.ToString(
                "dd/MM/yyyy HH:mm:ss");
    }

    // =========================
    // KIỂM TRA INPUT
    // =========================
    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(
            txtTenTheLoai.Text))
        {
            MessageBox.Show(
                "Tên thể loại không được để trống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtTenTheLoai.Focus();

            return false;
        }

        if (txtTenTheLoai.Text.Trim().Length > 100)
        {
            MessageBox.Show(
                "Tên thể loại không được vượt quá 100 ký tự!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtTenTheLoai.Focus();

            return false;
        }

        if (txtMoTa.Text.Trim().Length > 255)
        {
            MessageBox.Show(
                "Mô tả không được vượt quá 255 ký tự!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtMoTa.Focus();

            return false;
        }

        return true;
    }

    // =========================
    // THÊM
    // =========================
    private async void btnThem_Click(
    object sender,
    EventArgs e)
    {
        if (!ValidateInput())
            return;

        string tenTheLoai =
            txtTenTheLoai.Text.Trim();

        string? moTa =
            string.IsNullOrWhiteSpace(txtMoTa.Text)
                ? null
                : txtMoTa.Text.Trim();

        try
        {
            using var context =
                new TriThucBooksContext();

            // Kiểm tra trùng tên
            bool daTonTai =
                await context.TheLoaiSaches
                    .AnyAsync(x =>
                        x.TenTheLoai == tenTheLoai);

            if (daTonTai)
            {
                MessageBox.Show(
                    "Tên thể loại đã tồn tại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenTheLoai.Focus();
                return;
            }

            var theLoaiMoi =
                new TheLoaiSach
                {
                    TenTheLoai = tenTheLoai,
                    MoTa = moTa,
                    SoLuongSach = 0
                };

            context.TheLoaiSaches.Add(theLoaiMoi);

            // Lưu xuống SQL Server
            await context.SaveChangesAsync();

            // Lấy lại dữ liệu thật vừa được SQL Server tạo
            // bao gồm MaTL Identity và NgayTao = GETDATE()
            await context.Entry(theLoaiMoi)
                .ReloadAsync();

            // Load lại DataGridView
            await LoadDataAsync();

            // Hiển thị bản ghi vừa thêm lên Form
            txtMaTL.Text =
                theLoaiMoi.MaTl.ToString();

            txtTenTheLoai.Text =
                theLoaiMoi.TenTheLoai;

            txtMoTa.Text =
                theLoaiMoi.MoTa ?? "";

            lblNgayTao.Text =
                theLoaiMoi.NgayTao
                    .ToString("dd/MM/yyyy HH:mm:ss");

            // Chọn luôn dòng vừa thêm trong DataGridView
            dgvTheLoaiSach.ClearSelection();

            foreach (DataGridViewRow row
                     in dgvTheLoaiSach.Rows)
            {
                if (row.DataBoundItem
                        is TheLoaiSach item
                    && item.MaTl == theLoaiMoi.MaTl)
                {
                    row.Selected = true;

                    dgvTheLoaiSach.CurrentCell =
                        row.Cells[0];

                    break;
                }
            }

            MessageBox.Show(
                "Thêm thể loại thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể thêm dữ liệu.\n" +
                "Có thể tên thể loại đã tồn tại.\n\n" +
                (ex.InnerException?.Message
                 ?? ex.Message),
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Có lỗi xảy ra:\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================
    // SỬA
    // =========================
    private async void btnSua_Click(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            txtMaTL.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn thể loại cần sửa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!ValidateInput())
            return;

        if (!int.TryParse(
            txtMaTL.Text,
            out int maTL))
        {
            MessageBox.Show(
                "Mã thể loại không hợp lệ!",
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            return;
        }

        string tenTheLoai =
            txtTenTheLoai.Text.Trim();

        string? moTa =
            string.IsNullOrWhiteSpace(txtMoTa.Text)
                ? null
                : txtMoTa.Text.Trim();

        try
        {
            using var context =
                new TriThucBooksContext();

            var theLoai =
                await context.TheLoaiSaches
                    .FirstOrDefaultAsync(
                        x => x.MaTl == maTL);

            if (theLoai == null)
            {
                MessageBox.Show(
                    "Không tìm thấy thể loại cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                await LoadDataAsync();

                return;
            }

            // Kiểm tra trùng tên với bản ghi khác
            bool trungTen =
                await context.TheLoaiSaches
                    .AnyAsync(x =>
                        x.TenTheLoai == tenTheLoai
                        && x.MaTl != maTL);

            if (trungTen)
            {
                MessageBox.Show(
                    "Tên thể loại đã tồn tại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenTheLoai.Focus();

                return;
            }

            theLoai.TenTheLoai =
                tenTheLoai;

            theLoai.MoTa =
                moTa;

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Cập nhật thể loại thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();

            ClearInput();
        }
        catch (DbUpdateException ex)
        {
            MessageBox.Show(
                "Không thể cập nhật dữ liệu.\n\n"
                + ex.InnerException?.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Có lỗi xảy ra:\n"
                + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================
    // XÓA
    // =========================
    private async void btnXoa_Click(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            txtMaTL.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn thể loại cần xóa!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        if (!int.TryParse(
            txtMaTL.Text,
            out int maTL))
        {
            return;
        }

        string ten =
            txtTenTheLoai.Text.Trim();

        DialogResult result =
            MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thể loại:\n\n{ten} ?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        try
        {
            using var context =
                new TriThucBooksContext();

            var theLoai =
                await context.TheLoaiSaches
                    .FirstOrDefaultAsync(
                        x => x.MaTl == maTL);

            if (theLoai == null)
            {
                MessageBox.Show(
                    "Không tìm thấy thể loại cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                await LoadDataAsync();

                return;
            }

            context.TheLoaiSaches.Remove(
                theLoai);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Xóa thể loại thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();

            ClearInput();
        }
        catch (DbUpdateException)
        {
            MessageBox.Show(
                "Không thể xóa thể loại này!\n\n" +
                "Thể loại đang được sách khác tham chiếu.",
                "Lỗi ràng buộc dữ liệu",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Có lỗi xảy ra:\n"
                + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // =========================
    // LÀM MỚI
    // =========================
    private async void btnLamMoi_Click(
        object sender,
        EventArgs e)
    {
        txtTimKiem.Clear();

        await LoadDataAsync();

        ClearInput();
    }

    // =========================
    // TÌM KIẾM
    // =========================
    private async Task TimKiemAsync()
    {
        string tuKhoa =
            txtTimKiem.Text.Trim();

        try
        {
            using var context =
                new TriThucBooksContext();

            if (string.IsNullOrWhiteSpace(
                tuKhoa))
            {
                await LoadDataAsync();

                return;
            }

            var ketQua =
                await context.TheLoaiSaches
                    .AsNoTracking()

                    // LINQ Where + Contains
                    .Where(x =>
                        x.TenTheLoai.Contains(
                            tuKhoa))

                    .OrderBy(x => x.MaTl)

                    .ToListAsync();

            dgvTheLoaiSach.DataSource =
                ketQua;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Có lỗi khi tìm kiếm:\n"
                + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void btnTimKiem_Click(
        object sender,
        EventArgs e)
    {
        await TimKiemAsync();
    }

    // Tìm trực tiếp khi nhập
    private async void txtTimKiem_TextChanged(
        object sender,
        EventArgs e)
    {
        await TimKiemAsync();
    }
}