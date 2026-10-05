using Microsoft.EntityFrameworkCore;
using Cau3LTTQ.Models;

namespace Cau3LTTQ;

public partial class Form1 : Form
{
    // Tên file ảnh đang chọn
    private string? _tenFileAnh;

    public Form1()
    {
        InitializeComponent();
    }

    // ======================================
    // LỚP HIỂN THỊ DATAGRIDVIEW
    // ======================================
    private class PhongView
    {
        public int MaPhong { get; set; }

        public Image? Anh { get; set; }

        public string SoPhong { get; set; } = "";

        public int? TangSo { get; set; }

        public int? MaLoai { get; set; }

        public string TenLoai { get; set; } = "";

        public decimal? GiaMoiDem { get; set; }

        public string TinhTrang { get; set; } = "";

        public string? HinhAnh { get; set; }
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
    // ĐƯỜNG DẪN THƯ MỤC IMAGES
    // ======================================
    private string ImagesFolder =>
        Path.Combine(
            Application.StartupPath,
            "Images");

    // ======================================
    // LOAD FORM
    // ======================================
    private async void Form1_Load(
        object sender,
        EventArgs e)
    {
        TaoThuMucImages();

        LoadTinhTrang();

        await LoadLoaiPhongAsync();

        await LoadPhongAsync();

        ClearInput();
    }

    // ======================================
    // TẠO THƯ MỤC IMAGES
    // ======================================
    private void TaoThuMucImages()
    {
        if (!Directory.Exists(
            ImagesFolder))
        {
            Directory.CreateDirectory(
                ImagesFolder);
        }
    }

    // ======================================
    // LOAD TÌNH TRẠNG
    // ======================================
    private void LoadTinhTrang()
    {
        cboTinhTrang.Items.Clear();

        cboTinhTrang.Items.Add("Trống");
        cboTinhTrang.Items.Add("Đang ở");
        cboTinhTrang.Items.Add("Đang dọn");

        cboTinhTrang.SelectedIndex = 0;


        cboTimTinhTrang.Items.Clear();

        cboTimTinhTrang.Items.Add("Trống");
        cboTimTinhTrang.Items.Add("Đang ở");
        cboTimTinhTrang.Items.Add("Đang dọn");

        cboTimTinhTrang.SelectedIndex = 0;
    }

    // ======================================
    // LOAD LOẠI PHÒNG
    // ======================================
    private async Task LoadLoaiPhongAsync()
    {
        try
        {
            using var context =
                CreateContext();

            var danhSach =
                await context.LoaiPhongs
                    .AsNoTracking()
                    .OrderBy(x => x.TenLoai)
                    .ToListAsync();

            // Combo nhập liệu
            cboLoaiPhong.DataSource = null;

            cboLoaiPhong.DataSource =
                danhSach.ToList();

            cboLoaiPhong.DisplayMember =
                "TenLoai";

            cboLoaiPhong.ValueMember =
                "MaLoai";


            // Combo tìm kiếm
            cboTimLoaiPhong.DataSource = null;

            cboTimLoaiPhong.DataSource =
                danhSach.ToList();

            cboTimLoaiPhong.DisplayMember =
                "TenLoai";

            cboTimLoaiPhong.ValueMember =
                "MaLoai";
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không tải được loại phòng!\n\n"
                + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // ======================================
    // LOAD DANH SÁCH PHÒNG
    // INCLUDE LOẠI PHÒNG
    // ======================================
    private async Task LoadPhongAsync()
    {
        try
        {
            using var context =
                CreateContext();

            var danhSach =
                await context.Phongs

                    // EAGER LOADING
                    .Include(
                        x =>
                            x.MaLoaiNavigation)

                    .AsNoTracking()

                    .OrderBy(
                        x => x.MaPhong)

                    .ToListAsync();

            BindDataGridView(
                danhSach);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không tải được danh sách phòng!\n\n"
                + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // ======================================
    // ĐỔ ENTITY SANG DATAGRIDVIEW
    // ======================================
    private void BindDataGridView(
        List<Phong> danhSach)
    {
        DisposeGridImages();

        var data =
            danhSach.Select(
                x => new PhongView
                {
                    MaPhong =
                        x.MaPhong,

                    Anh =
                        LoadThumbnail(
                            x.HinhAnh),

                    SoPhong =
                        x.SoPhong,

                    TangSo =
                        x.TangSo,

                    MaLoai =
                        x.MaLoai,

                    TenLoai =
                        x.MaLoaiNavigation
                            ?.TenLoai
                        ?? "",

                    GiaMoiDem =
                        x.MaLoaiNavigation
                            ?.GiaMoiDem,

                    TinhTrang =
                        x.TinhTrang ?? "",

                    HinhAnh =
                        x.HinhAnh
                })
                .ToList();

        dgvPhong.DataSource = null;

        dgvPhong.DataSource =
            data;

        dgvPhong.ClearSelection();
    }

    // ======================================
    // LOAD THUMBNAIL
    // ======================================
    private Image? LoadThumbnail(
        string? tenFile)
    {
        if (string.IsNullOrWhiteSpace(
            tenFile))
        {
            return null;
        }

        string path =
            Path.Combine(
                ImagesFolder,
                tenFile);

        if (!File.Exists(path))
            return null;

        try
        {
            using var stream =
                new FileStream(
                    path,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite);

            using var img =
                Image.FromStream(stream);

            return new Bitmap(
                img,
                new Size(100, 65));
        }
        catch
        {
            return null;
        }
    }

    // ======================================
    // HIỂN THỊ ẢNH TRÊN PICTUREBOX
    // ======================================
    private void HienThiAnh(
        string? tenFile)
    {
        if (picPhong.Image != null)
        {
            var anhCu =
                picPhong.Image;

            picPhong.Image = null;

            anhCu.Dispose();
        }

        if (string.IsNullOrWhiteSpace(
            tenFile))
        {
            return;
        }

        string path =
            Path.Combine(
                ImagesFolder,
                tenFile);

        if (!File.Exists(path))
            return;

        try
        {
            using var stream =
                new FileStream(
                    path,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.ReadWrite);

            using var img =
                Image.FromStream(stream);

            picPhong.Image =
                new Bitmap(img);
        }
        catch
        {
            picPhong.Image = null;
        }
    }

    // ======================================
    // CHỌN ẢNH
    // ======================================
    private void btnChonAnh_Click(
        object sender,
        EventArgs e)
    {
        using var openFile =
            new OpenFileDialog();

        openFile.Title =
            "Chọn ảnh phòng";

        openFile.Filter =
            "File ảnh|*.jpg;*.jpeg;*.png;*.bmp";

        if (openFile.ShowDialog()
            != DialogResult.OK)
        {
            return;
        }

        TaoThuMucImages();

        string extension =
            Path.GetExtension(
                openFile.FileName);

        // Đổi tên để tránh trùng file
        string tenFileMoi =
            Guid.NewGuid()
                .ToString("N")
            + extension;

        string duongDanMoi =
            Path.Combine(
                ImagesFolder,
                tenFileMoi);

        File.Copy(
            openFile.FileName,
            duongDanMoi,
            true);

        // Chỉ lưu tên file
        _tenFileAnh =
            tenFileMoi;

        HienThiAnh(
            _tenFileAnh);
    }

    // ======================================
    // CHỌN DÒNG DATAGRIDVIEW
    // ======================================
    private void dgvPhong_SelectionChanged(
        object sender,
        EventArgs e)
    {
        if (dgvPhong.CurrentRow?.DataBoundItem
            is not PhongView phong)
        {
            return;
        }

        txtMaPhong.Text =
            phong.MaPhong.ToString();

        txtSoPhong.Text =
            phong.SoPhong;

        numTangSo.Value =
            phong.TangSo ?? 0;

        if (phong.MaLoai.HasValue)
        {
            cboLoaiPhong.SelectedValue =
                phong.MaLoai.Value;
        }

        cboTinhTrang.SelectedItem =
            phong.TinhTrang;

        _tenFileAnh =
            phong.HinhAnh;

        HienThiAnh(
            phong.HinhAnh);
    }

    // ======================================
    // CLEAR FORM
    // ======================================
    private void ClearInput()
    {
        txtMaPhong.Clear();

        txtSoPhong.Clear();

        numTangSo.Value = 0;

        if (cboLoaiPhong.Items.Count > 0)
        {
            cboLoaiPhong.SelectedIndex = 0;
        }

        if (cboTinhTrang.Items.Count > 0)
        {
            cboTinhTrang.SelectedIndex = 0;
        }

        _tenFileAnh = null;

        HienThiAnh(null);

        dgvPhong.ClearSelection();

        txtSoPhong.Focus();
    }

    // ======================================
    // VALIDATE
    // ======================================
    private bool ValidateInput()
    {
        if (string.IsNullOrWhiteSpace(
            txtSoPhong.Text))
        {
            MessageBox.Show(
                "Số phòng không được để trống!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtSoPhong.Focus();

            return false;
        }

        if (txtSoPhong.Text.Trim().Length > 10)
        {
            MessageBox.Show(
                "Số phòng không được vượt quá 10 ký tự!");

            txtSoPhong.Focus();

            return false;
        }

        if (cboLoaiPhong.SelectedValue == null)
        {
            MessageBox.Show(
                "Vui lòng chọn loại phòng!");

            return false;
        }

        if (cboTinhTrang.SelectedItem == null)
        {
            MessageBox.Show(
                "Vui lòng chọn tình trạng phòng!");

            return false;
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

            string soPhong =
                txtSoPhong.Text.Trim();

            bool trungSoPhong =
                await context.Phongs
                    .AnyAsync(
                        x =>
                            x.SoPhong == soPhong);

            if (trungSoPhong)
            {
                MessageBox.Show(
                    "Số phòng này đã tồn tại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSoPhong.Focus();

                return;
            }

            var phong =
                new Phong
                {
                    SoPhong =
                        soPhong,

                    TangSo =
                        (int)numTangSo.Value,

                    TinhTrang =
                        cboTinhTrang
                            .SelectedItem!
                            .ToString(),

                    HinhAnh =
                        _tenFileAnh,

                    MaLoai =
                        Convert.ToInt32(
                            cboLoaiPhong
                                .SelectedValue)
                };

            context.Phongs.Add(
                phong);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Thêm phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadPhongAsync();

            ClearInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể thêm phòng!\n\n"
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
            txtMaPhong.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn phòng cần sửa!");

            return;
        }

        if (!ValidateInput())
            return;

        int maPhong =
            int.Parse(
                txtMaPhong.Text);

        try
        {
            using var context =
                CreateContext();

            var phong =
                await context.Phongs
                    .FirstOrDefaultAsync(
                        x =>
                            x.MaPhong == maPhong);

            if (phong == null)
            {
                MessageBox.Show(
                    "Không tìm thấy phòng!");

                return;
            }

            string soPhongMoi =
                txtSoPhong.Text.Trim();

            bool trungSoPhong =
                await context.Phongs
                    .AnyAsync(
                        x =>
                            x.SoPhong
                                == soPhongMoi
                            &&
                            x.MaPhong
                                != maPhong);

            if (trungSoPhong)
            {
                MessageBox.Show(
                    "Số phòng này đã tồn tại!");

                return;
            }

            phong.SoPhong =
                soPhongMoi;

            phong.TangSo =
                (int)numTangSo.Value;

            phong.TinhTrang =
                cboTinhTrang
                    .SelectedItem!
                    .ToString();

            phong.HinhAnh =
                _tenFileAnh;

            phong.MaLoai =
                Convert.ToInt32(
                    cboLoaiPhong
                        .SelectedValue);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Cập nhật phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadPhongAsync();

            ClearInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể cập nhật phòng!\n\n"
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
            txtMaPhong.Text))
        {
            MessageBox.Show(
                "Vui lòng chọn phòng cần xóa!");

            return;
        }

        int maPhong =
            int.Parse(
                txtMaPhong.Text);

        DialogResult result =
            MessageBox.Show(
                "Bạn có chắc chắn muốn xóa phòng "
                + txtSoPhong.Text + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        if (result != DialogResult.Yes)
            return;

        try
        {
            using var context =
                CreateContext();

            var phong =
                await context.Phongs
                    .FirstOrDefaultAsync(
                        x =>
                            x.MaPhong == maPhong);

            if (phong == null)
            {
                MessageBox.Show(
                    "Không tìm thấy phòng!");

                return;
            }

            context.Phongs.Remove(
                phong);

            await context.SaveChangesAsync();

            MessageBox.Show(
                "Xóa phòng thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            await LoadPhongAsync();

            ClearInput();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể xóa phòng!\n\n"
                + ex.Message,
                "Lỗi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    // ======================================
    // TÌM KIẾM
    // LOẠI PHÒNG && TÌNH TRẠNG
    // ======================================
    private async void btnTimKiem_Click(
        object sender,
        EventArgs e)
    {
        if (cboTimLoaiPhong.SelectedValue == null
            ||
            cboTimTinhTrang.SelectedItem == null)
        {
            MessageBox.Show(
                "Vui lòng chọn loại phòng và tình trạng!");

            return;
        }

        int maLoai =
            Convert.ToInt32(
                cboTimLoaiPhong
                    .SelectedValue);

        string tinhTrang =
            cboTimTinhTrang
                .SelectedItem!
                .ToString()!;

        try
        {
            using var context =
                CreateContext();

            var ketQua =
                await context.Phongs

                    // INCLUDE lấy LoaiPhong
                    .Include(
                        x =>
                            x.MaLoaiNavigation)

                    .AsNoTracking()

                    // 2 điều kiện &&
                    .Where(
                        x =>
                            x.MaLoai == maLoai
                            &&
                            x.TinhTrang
                                == tinhTrang)

                    .OrderBy(
                        x => x.MaPhong)

                    .ToListAsync();

            BindDataGridView(
                ketQua);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Không thể tìm kiếm!\n\n"
                + ex.Message,
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
        await LoadLoaiPhongAsync();

        await LoadPhongAsync();

        if (cboTimLoaiPhong.Items.Count > 0)
        {
            cboTimLoaiPhong.SelectedIndex = 0;
        }

        if (cboTimTinhTrang.Items.Count > 0)
        {
            cboTimTinhTrang.SelectedIndex = 0;
        }

        ClearInput();
    }

    // ======================================
    // MỞ FORM QUẢN LÝ LOẠI PHÒNG
    // ======================================
    private async void btnQuanLyLoaiPhong_Click(
        object sender,
        EventArgs e)
    {
        using var form =
            new FrmLoaiPhong();

        form.ShowDialog(this);

        // Sau khi thêm/sửa/xóa loại phòng,
        // load lại ComboBox
        await LoadLoaiPhongAsync();

        await LoadPhongAsync();

        ClearInput();
    }

    // ======================================
    // GIẢI PHÓNG ẢNH DATAGRIDVIEW
    // ======================================
    private void DisposeGridImages()
    {
        if (dgvPhong.DataSource
            is IEnumerable<PhongView> danhSach)
        {
            foreach (var item in danhSach)
            {
                item.Anh?.Dispose();
            }
        }
    }

    // ======================================
    // ĐÓNG FORM
    // ======================================
    private void Form1_FormClosed(
        object sender,
        FormClosedEventArgs e)
    {
        DisposeGridImages();

        if (picPhong.Image != null)
        {
            picPhong.Image.Dispose();

            picPhong.Image = null;
        }
    }
}