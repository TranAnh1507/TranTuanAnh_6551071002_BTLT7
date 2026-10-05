namespace Cau2LTTQ.Models;

public partial class HoiVien
{
    public int MaHv { get; set; }

    public string HoTen { get; set; } = null!;

    // true = Nam, false = Nữ
    public bool GioiTinh { get; set; }

    public DateTime NgaySinh { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? HangThanhVien { get; set; }

    public DateTime NgayDangKy { get; set; }

    // true = Đang hoạt động
    // false = Tạm ngưng
    public bool TrangThai { get; set; }
}