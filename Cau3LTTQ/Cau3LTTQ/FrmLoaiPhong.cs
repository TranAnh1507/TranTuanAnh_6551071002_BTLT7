using Microsoft.EntityFrameworkCore;
using Cau3LTTQ.Models;

namespace Cau3LTTQ;

public partial class FrmLoaiPhong : Form
{
    public FrmLoaiPhong()
    {
        InitializeComponent();
    }

    // ======================================
    // TẠO CONTEXT EF CORE
    // ======================================
    private Cau3LTTQContext CreateContext()
    {
        var options =
            new DbContextOptionsBuilder<Cau3LTTQContext>()
                .UseSqlServer(
                    @"Server=localhost\SQLEXPRESS;" +
                    @"Database=Cau3LTTQ;" +
                    @"Trusted_Connection=True;" +
                    @"TrustServerCertificate=True;")
                .Options;

        return new Cau3LTTQContext(options);
    }

    // ======================================
    // LOAD FORM
    // ======================================
    private async void FrmLoaiPhong_Load(
        object sender,
        EventArgs e)
    {
        await LoadDataAsync();
        ClearInput();
    }

    // ======================================
    // LOAD DATAGRIDVIEW
    // ======================================
    private async Task LoadDataAsync()
    {
        try
        {
            using var context = CreateContext();

            var danhSach =
                await context.LoaiPhongs
                    .AsNoTracking()
                    .OrderBy(x => x.MaLoai)
                    .ToListAsync();

            dgvLoaiPhong.DataSource = null;
            dgvLoaiPhong.DataSource = danhSach;

            dgvLoaiPhong.ClearSelection();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể tải loại phòng!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // ======================================
    // CLEAR
    // ======================================
    private void ClearInput()
    {
        txtMaLoai.Clear();
        txtTenLoai.Clear();
        txtMoTa.Clear();

        numGia.Value = 0;

        dgvLoaiPhong.ClearSelection();

        txtTenLoai.Focus();
    }

    // ======================================
    // VALIDATE
    // ======================================
    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(
            txtTenLoai.Text))
        {
            MessageBox.Show(
                "Tên loại phòng không được để trống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtTenLoai.Focus();

            return false;
        }

        if (numGia.Value <= 0)
        {
            MessageBox.Show(
                "Giá mỗi đêm phải lớn hơn 0!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            numGia.Focus();

            return false;
        }

        if (txtMoTa.Text.Trim().Length > 255)
        {
            MessageBox.Show(
                "Mô tả không được vượt quá 255 ký tự!");

            txtMoTa.Focus();

            return false;
        }

        return true;
    }

    // ======================================
    // CHỌN DÒNG
    // ======================================
    private void dgvLoaiPhong_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (dgvLoaiPhong.CurrentRow?.DataBoundItem
            is not LoaiPhong loai)
        {
            return;
        }

        txtMaLoai.Text =
            loai.MaLoai.ToString();

        txtTenLoai.Text =
            loai.TenLoai;

        numGia.Value =
            loai.GiaMoiDem ?? 0;

        txtMoTa.Text =
            loai.MoTa ?? "";
    }

    // ======================================
    // THÊM
    // ======================================
    private async void btnThem_Click(
        object sender,
        EventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            using var context = CreateContext();

            var loaiPhong =
                new LoaiPhong
                {
                    TenLoai =
                        txtTenLoai.Text.Trim(),

                    GiaMoiDem =
                        numGia.Value,

                    MoTa =
                        string.IsNullOrWhiteSpace(
                            txtMoTa.Text)
                            ? null
                            : txtMoTa.Text.Trim()
                };

            context.LoaiPhongs.Add(
                loaiPhong);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Thêm loại phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();

            ClearInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể thêm loại phòng!\n\n"
                + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // ======================================
    // SỬA
    // ======================================
    private async void btnSua_Click(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            txtMaLoai.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn loại phòng cần sửa!");

            return;
        }

        if (!ValidateInput())
            return;

        int maLoai =
            int.Parse(txtMaLoai.Text);

        try
        {
            using var context =
                CreateContext();

            var loaiPhong =
                await context.LoaiPhongs
                    .FirstOrDefaultAsync(
                        x => x.MaLoai == maLoai);

            if (loaiPhong == null)
            {
                MessageBox.Show(
                    "Không tìm thấy loại phòng!");

                return;
            }

            loaiPhong.TenLoai =
                txtTenLoai.Text.Trim();

            loaiPhong.GiaMoiDem =
                numGia.Value;

            loaiPhong.MoTa =
                string.IsNullOrWhiteSpace(
                    txtMoTa.Text)
                    ? null
                    : txtMoTa.Text.Trim();

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Cập nhật loại phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();

            ClearInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể cập nhật loại phòng!\n\n"
                + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // ======================================
    // XÓA
    // ======================================
    private async void btnXoa_Click(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            txtMaLoai.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn loại phòng cần xóa!");

            return;
        }

        int maLoai =
            int.Parse(txtMaLoai.Text);

        DialogResult result =
            MessageBox.Show(
                "Bạn có chắc chắn muốn xóa loại phòng:\n\n" +
                txtTenLoai.Text + " ?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        try
        {
            using var context =
                CreateContext();

            var loaiPhong =
                await context.LoaiPhongs
                    .FirstOrDefaultAsync(
                        x => x.MaLoai == maLoai);

            if (loaiPhong == null)
            {
                MessageBox.Show(
                    "Không tìm thấy loại phòng!");

                return;
            }

            context.LoaiPhongs.Remove(
                loaiPhong);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Xóa loại phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();

            ClearInput();
        }
        catch (DbUpdateException)
        {
            MessageBox.Show(
                "Không thể xóa loại phòng này!\n\n" +
                "Đang có phòng sử dụng loại phòng này.",
                "Lỗi ràng buộc",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    // ======================================
    // LÀM MỚI
    // ======================================
    private async void btnLamMoi_Click(
        object sender,
        EventArgs e)
    {
        await LoadDataAsync();

        ClearInput();
    }
}