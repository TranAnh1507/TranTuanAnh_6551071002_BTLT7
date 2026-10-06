using Microsoft.EntityFrameworkCore;
using Cau4LTTQ.Models;

namespace Cau4LTTQ;

public partial class FrmBacSi : Form
{
    public FrmBacSi()
    {
        InitializeComponent();
    }

    private Cau4LTTQContext CreateContext()
    {
        var options =
            new DbContextOptionsBuilder<Cau4LTTQContext>()
                .UseSqlServer(
                    @"Server=localhost\SQLEXPRESS;" +
                    @"Database=Cau4LTTQ;" +
                    @"Trusted_Connection=True;" +
                    @"TrustServerCertificate=True;")
                .Options;

        return new Cau4LTTQContext(options);
    }

    private async void FrmBacSi_Load(
        object sender,
        EventArgs e)
    {
        await LoadDataAsync();
        ClearInput();
    }

    private async Task LoadDataAsync()
    {
        try
        {
            using var context = CreateContext();

            var danhSach =
                await context.BacSis
                    .AsNoTracking()
                    .OrderBy(x => x.MaBs)
                    .ToListAsync();

            dgvBacSi.DataSource = null;
            dgvBacSi.DataSource = danhSach;

            dgvBacSi.ClearSelection();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể tải danh sách bác sĩ!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void ClearInput()
    {
        txtMaBS.Clear();
        txtHoTen.Clear();
        txtChuyenKhoa.Clear();
        txtSDT.Clear();

        dgvBacSi.ClearSelection();

        txtHoTen.Focus();
    }

    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(txtHoTen.Text))
        {
            MessageBox.Show(
                "Họ tên bác sĩ không được để trống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtHoTen.Focus();

            return false;
        }

        string sdt = txtSDT.Text.Trim();

        if (!string.IsNullOrEmpty(sdt))
        {
            if (!sdt.All(char.IsDigit))
            {
                MessageBox.Show(
                    "Số điện thoại chỉ được chứa chữ số!");

                txtSDT.Focus();

                return false;
            }

            if (sdt.Length < 9 ||
                sdt.Length > 11)
            {
                MessageBox.Show(
                    "Số điện thoại phải từ 9 đến 11 chữ số!");

                txtSDT.Focus();

                return false;
            }
        }

        return true;
    }

    private void dgvBacSi_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (dgvBacSi.CurrentRow?.DataBoundItem
            is not BacSi bacSi)
        {
            return;
        }

        txtMaBS.Text =
            bacSi.MaBs.ToString();

        txtHoTen.Text =
            bacSi.HoTen;

        txtChuyenKhoa.Text =
            bacSi.ChuyenKhoa ?? "";

        txtSDT.Text =
            bacSi.Sdt ?? "";
    }

    private async void btnThem_Click(
        object sender,
        EventArgs e)
    {
        if (!ValidateInput())
            return;

        try
        {
            using var context =
                CreateContext();

            var bacSi =
                new BacSi
                {
                    HoTen =
                        txtHoTen.Text.Trim(),

                    ChuyenKhoa =
                        string.IsNullOrWhiteSpace(
                            txtChuyenKhoa.Text)
                            ? null
                            : txtChuyenKhoa.Text.Trim(),

                    Sdt =
                        string.IsNullOrWhiteSpace(
                            txtSDT.Text)
                            ? null
                            : txtSDT.Text.Trim()
                };

            context.BacSis.Add(bacSi);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Thêm bác sĩ thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadDataAsync();
            ClearInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể thêm bác sĩ!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void btnSua_Click(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            txtMaBS.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn bác sĩ cần sửa!");

            return;
        }

        if (!ValidateInput())
            return;

        int maBS =
            int.Parse(txtMaBS.Text);

        try
        {
            using var context =
                CreateContext();

            var bacSi =
                await context.BacSis
                    .FirstOrDefaultAsync(
                        x => x.MaBs == maBS);

            if (bacSi == null)
            {
                MessageBox.Show(
                    "Không tìm thấy bác sĩ!");

                return;
            }

            bacSi.HoTen =
                txtHoTen.Text.Trim();

            bacSi.ChuyenKhoa =
                string.IsNullOrWhiteSpace(
                    txtChuyenKhoa.Text)
                    ? null
                    : txtChuyenKhoa.Text.Trim();

            bacSi.Sdt =
                string.IsNullOrWhiteSpace(
                    txtSDT.Text)
                    ? null
                    : txtSDT.Text.Trim();

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Cập nhật bác sĩ thành công!");

            await LoadDataAsync();
            ClearInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể cập nhật bác sĩ!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private async void btnXoa_Click(
        object sender,
        EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(
            txtMaBS.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn bác sĩ cần xóa!");

            return;
        }

        int maBS =
            int.Parse(txtMaBS.Text);

        DialogResult result =
            MessageBox.Show(
                "Bạn có chắc chắn muốn xóa bác sĩ:\n\n" +
                txtHoTen.Text + " ?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        try
        {
            using var context =
                CreateContext();

            var bacSi =
                await context.BacSis
                    .FirstOrDefaultAsync(
                        x => x.MaBs == maBS);

            if (bacSi == null)
                return;

            context.BacSis.Remove(bacSi);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Xóa bác sĩ thành công!");

            await LoadDataAsync();
            ClearInput();
        }
        catch (DbUpdateException)
        {
            MessageBox.Show(
                "Không thể xóa bác sĩ này!\n\n" +
                "Bác sĩ đang có lịch khám.",
                "Lỗi ràng buộc",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }

    private async void btnLamMoi_Click(
        object sender,
        EventArgs e)
    {
        await LoadDataAsync();
        ClearInput();
    }
}