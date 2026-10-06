using Microsoft.EntityFrameworkCore;
using Cau4LTTQ.Models;

namespace Cau4LTTQ;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    // ======================================
    // CLASS HIỂN THỊ BÁC SĨ TRONG COMBOBOX
    // ======================================
    private class BacSiComboItem
    {
        public int MaBs { get; set; }

        public string HienThi { get; set; } = "";
    }

    // ======================================
    // CLASS HIỂN THỊ DATAGRIDVIEW
    // ======================================
    private class LichKhamView
    {
        public int MaLich { get; set; }

        public string TenBenhNhan { get; set; } = "";

        public string Sdt { get; set; } = "";

        public DateOnly NgayKham { get; set; }

        public TimeOnly GioKham { get; set; }

        public int MaBs { get; set; }

        public string TenBacSi { get; set; } = "";

        public string ChuyenKhoa { get; set; } = "";

        public string TrangThai { get; set; } = "";

        public string NgayKhamText =>
            NgayKham.ToString("dd/MM/yyyy");

        public string GioKhamText =>
            GioKham.ToString("HH:mm");
    }

    // ======================================
    // KẾT NỐI EF CORE
    // ======================================
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

    // ======================================
    // LOAD FORM
    // ======================================
    private async void Form1_Load(
        object sender,
        EventArgs e)
    {
        LoadTrangThai();

        await LoadBacSiAsync();

        await LoadLichKhamAsync();

        ClearInput();

        dtpTuNgay.Value =
            DateTime.Today;

        dtpDenNgay.Value =
            DateTime.Today.AddMonths(1);
    }

    // ======================================
    // TRẠNG THÁI
    // ======================================
    private void LoadTrangThai()
    {
        cboTrangThai.Items.Clear();

        cboTrangThai.Items.Add("Chờ khám");
        cboTrangThai.Items.Add("Đã khám");
        cboTrangThai.Items.Add("Đã hủy");

        cboTrangThai.SelectedIndex = 0;
    }

    // ======================================
    // LOAD BÁC SĨ VÀO COMBOBOX
    // ======================================
    private async Task LoadBacSiAsync()
    {
        try
        {
            using var context =
                CreateContext();

            var danhSach =
                await context.BacSis
                    .AsNoTracking()
                    .OrderBy(x => x.HoTen)
                    .ToListAsync();

            var comboData =
                danhSach.Select(
                    x => new BacSiComboItem
                    {
                        MaBs = x.MaBs,

                        HienThi =
                            "BS. " +
                            x.HoTen +
                            " - " +
                            (x.ChuyenKhoa ?? "")
                    })
                    .ToList();

            // Combo nhập liệu
            cboBacSi.DataSource = null;

            cboBacSi.DataSource =
                comboData.ToList();

            cboBacSi.DisplayMember =
                "HienThi";

            cboBacSi.ValueMember =
                "MaBs";

            // Combo tìm kiếm
            cboTimBacSi.DataSource = null;

            cboTimBacSi.DataSource =
                comboData.ToList();

            cboTimBacSi.DisplayMember =
                "HienThi";

            cboTimBacSi.ValueMember =
                "MaBs";
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

    // ======================================
    // LOAD LỊCH KHÁM
    // INCLUDE BÁC SĨ
    // ======================================
    private async Task LoadLichKhamAsync()
    {
        try
        {
            using var context =
                CreateContext();

            var danhSach =
                await context.LichKhams

                    // YÊU CẦU ĐỀ BÀI:
                    // LINQ INCLUDE
                    .Include(
                        x => x.MaBsNavigation)

                    .AsNoTracking()

                    .OrderBy(x => x.NgayKham)
                    .ThenBy(x => x.GioKham)

                    .ToListAsync();

            BindDataGridView(
                danhSach);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể tải lịch khám!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // ======================================
    // BIND DATAGRIDVIEW
    // ======================================
    private void BindDataGridView(
        List<LichKham> danhSach)
    {
        var data =
            danhSach.Select(
                x => new LichKhamView
                {
                    MaLich =
                        x.MaLich,

                    TenBenhNhan =
                        x.TenBenhNhan,

                    Sdt =
                        x.Sdt ?? "",

                    NgayKham =
                        x.NgayKham,

                    GioKham =
                        x.GioKham,

                    MaBs =
                        x.MaBs,

                    TenBacSi =
                        x.MaBsNavigation
                            ?.HoTen
                        ?? "",

                    ChuyenKhoa =
                        x.MaBsNavigation
                            ?.ChuyenKhoa
                        ?? "",

                    TrangThai =
                        x.TrangThai
                })
                .ToList();

        dgvLichKham.DataSource = null;

        dgvLichKham.DataSource =
            data;

        dgvLichKham.ClearSelection();
    }

    // ======================================
    // CLEAR INPUT
    // ======================================
    private void ClearInput()
    {
        txtMaLich.Clear();

        txtTenBenhNhan.Clear();

        txtSDT.Clear();

        dtpNgayKham.Value =
            DateTime.Today;

        dtpGioKham.Value =
            DateTime.Today
                .AddHours(8);

        if (cboBacSi.Items.Count > 0)
        {
            cboBacSi.SelectedIndex = 0;
        }

        cboTrangThai.SelectedIndex = 0;

        dgvLichKham.ClearSelection();

        txtTenBenhNhan.Focus();
    }

    // ======================================
    // CHỌN DÒNG
    // ======================================
    private void dgvLichKham_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (dgvLichKham.CurrentRow?.DataBoundItem
            is not LichKhamView lich)
        {
            return;
        }

        txtMaLich.Text =
            lich.MaLich.ToString();

        txtTenBenhNhan.Text =
            lich.TenBenhNhan;

        txtSDT.Text =
            lich.Sdt;

        dtpNgayKham.Value =
            lich.NgayKham.ToDateTime(
                TimeOnly.MinValue);

        DateTime gio =
            DateTime.Today
                .AddHours(
                    lich.GioKham.Hour)
                .AddMinutes(
                    lich.GioKham.Minute)
                .AddSeconds(
                    lich.GioKham.Second);

        dtpGioKham.Value =
            gio;

        cboBacSi.SelectedValue =
            lich.MaBs;

        cboTrangThai.SelectedItem =
            lich.TrangThai;
    }

    // ======================================
    // VALIDATE
    // ======================================
    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(
            txtTenBenhNhan.Text))
        {
            MessageBox.Show(
                "Tên bệnh nhân không được để trống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtTenBenhNhan.Focus();

            return false;
        }

        if (dtpNgayKham.Value.Date <
            DateTime.Today)
        {
            MessageBox.Show(
                "Không được đặt lịch khám vào ngày trong quá khứ!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            dtpNgayKham.Focus();

            return false;
        }

        if (cboBacSi.SelectedValue == null)
        {
            MessageBox.Show(
                "Vui lòng chọn bác sĩ!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            cboBacSi.Focus();

            return false;
        }

        string sdt =
            txtSDT.Text.Trim();

        if (!string.IsNullOrWhiteSpace(sdt))
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
                    "Số điện thoại phải có từ 9 đến 11 chữ số!");

                txtSDT.Focus();

                return false;
            }
        }

        return true;
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
            using var context =
                CreateContext();

            var lich =
                new LichKham
                {
                    TenBenhNhan =
                        txtTenBenhNhan
                            .Text
                            .Trim(),

                    Sdt =
                        string.IsNullOrWhiteSpace(
                            txtSDT.Text)
                            ? null
                            : txtSDT.Text.Trim(),

                    NgayKham =
                        DateOnly.FromDateTime(
                            dtpNgayKham
                                .Value.Date),

                    GioKham =
                        TimeOnly.FromDateTime(
                            dtpGioKham.Value),

                    MaBs =
                        Convert.ToInt32(
                            cboBacSi
                                .SelectedValue),

                    TrangThai =
                        cboTrangThai
                            .SelectedItem!
                            .ToString()!
                };

            context.LichKhams.Add(
                lich);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Thêm lịch khám thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadLichKhamAsync();

            ClearInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể thêm lịch khám!\n\n" +
                ex.Message,
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
            txtMaLich.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn lịch khám cần sửa!");

            return;
        }

        if (!ValidateInput())
            return;

        int maLich =
            int.Parse(
                txtMaLich.Text);

        try
        {
            using var context =
                CreateContext();

            var lich =
                await context.LichKhams
                    .FirstOrDefaultAsync(
                        x => x.MaLich == maLich);

            if (lich == null)
            {
                MessageBox.Show(
                    "Không tìm thấy lịch khám!");

                return;
            }

            lich.TenBenhNhan =
                txtTenBenhNhan
                    .Text
                    .Trim();

            lich.Sdt =
                string.IsNullOrWhiteSpace(
                    txtSDT.Text)
                    ? null
                    : txtSDT.Text.Trim();

            lich.NgayKham =
                DateOnly.FromDateTime(
                    dtpNgayKham.Value.Date);

            lich.GioKham =
                TimeOnly.FromDateTime(
                    dtpGioKham.Value);

            lich.MaBs =
                Convert.ToInt32(
                    cboBacSi.SelectedValue);

            lich.TrangThai =
                cboTrangThai
                    .SelectedItem!
                    .ToString()!;

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Cập nhật lịch khám thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadLichKhamAsync();

            ClearInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể cập nhật lịch khám!\n\n" +
                ex.Message,
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
            txtMaLich.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn lịch khám cần xóa!");

            return;
        }

        int maLich =
            int.Parse(
                txtMaLich.Text);

        // BẮT BUỘC YES/NO
        DialogResult result =
            MessageBox.Show(
                "Bạn có chắc chắn muốn xóa lịch khám của:\n\n" +
                txtTenBenhNhan.Text +
                " ?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        try
        {
            using var context =
                CreateContext();

            var lich =
                await context.LichKhams
                    .FirstOrDefaultAsync(
                        x =>
                            x.MaLich == maLich);

            if (lich == null)
            {
                MessageBox.Show(
                    "Không tìm thấy lịch khám!");

                return;
            }

            context.LichKhams.Remove(
                lich);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Xóa lịch khám thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadLichKhamAsync();

            ClearInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể xóa lịch khám!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // ======================================
    // TÌM KIẾM
    // TỪ NGÀY - ĐẾN NGÀY - BÁC SĨ
    // ======================================
    private async void btnTimKiem_Click(
        object sender,
        EventArgs e)
    {
        if (cboTimBacSi.SelectedValue == null)
        {
            MessageBox.Show(
                "Vui lòng chọn bác sĩ cần tìm!");

            return;
        }

        if (dtpTuNgay.Value.Date >
            dtpDenNgay.Value.Date)
        {
            MessageBox.Show(
                "Từ ngày không được lớn hơn Đến ngày!");

            return;
        }

        DateOnly tuNgay =
            DateOnly.FromDateTime(
                dtpTuNgay.Value.Date);

        DateOnly denNgay =
            DateOnly.FromDateTime(
                dtpDenNgay.Value.Date);

        int maBS =
            Convert.ToInt32(
                cboTimBacSi.SelectedValue);

        try
        {
            using var context =
                CreateContext();

            var ketQua =
                await context.LichKhams

                    // INCLUDE BÁC SĨ
                    .Include(
                        x =>
                            x.MaBsNavigation)

                    .AsNoTracking()

                    // ===========================
                    // ĐÚNG YÊU CẦU:
                    // >=, <=, ==, &&
                    // ===========================
                    .Where(
                        x =>
                            x.NgayKham >= tuNgay
                            &&
                            x.NgayKham <= denNgay
                            &&
                            x.MaBs == maBS)

                    .OrderBy(
                        x => x.NgayKham)

                    .ThenBy(
                        x => x.GioKham)

                    .ToListAsync();

            BindDataGridView(
                ketQua);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể tìm kiếm!\n\n" +
                ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // ======================================
    // LÀM MỚI
    // ======================================
    private async void btnLamMoi_Click(
        object sender,
        EventArgs e)
    {
        await LoadBacSiAsync();

        await LoadLichKhamAsync();

        dtpTuNgay.Value =
            DateTime.Today;

        dtpDenNgay.Value =
            DateTime.Today.AddMonths(1);

        ClearInput();
    }

    // ======================================
    // MỞ FORM QUẢN LÝ BÁC SĨ
    // ======================================
    private async void btnQuanLyBacSi_Click(
        object sender,
        EventArgs e)
    {
        using var form =
            new FrmBacSi();

        form.ShowDialog(this);

        // Sau khi CRUD bác sĩ
        // load ComboBox lại
        await LoadBacSiAsync();

        await LoadLichKhamAsync();

        ClearInput();
    }
}