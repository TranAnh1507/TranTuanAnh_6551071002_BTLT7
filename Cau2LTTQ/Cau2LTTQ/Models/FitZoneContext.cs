using Microsoft.EntityFrameworkCore;

namespace Cau2LTTQ.Models;

public partial class FitZoneContext : DbContext
{
    public FitZoneContext()
    {
    }

    public FitZoneContext(
        DbContextOptions<FitZoneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HoiVien> HoiViens { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost\SQLEXPRESS;" +
                @"Database=Cau2LTTQ;" +
                @"Trusted_Connection=True;" +
                @"TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HoiVien>(entity =>
        {
            entity.HasKey(e => e.MaHv);

            entity.ToTable("HoiVien");

            entity.Property(e => e.MaHv)
                .HasColumnName("MaHV");

            entity.Property(e => e.HoTen)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(e => e.GioiTinh);

            entity.Property(e => e.NgaySinh)
                .HasColumnType("date");

            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.HangThanhVien)
                .HasMaxLength(20);

            entity.Property(e => e.NgayDangKy)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.TrangThai)
                .HasDefaultValue(true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(
        ModelBuilder modelBuilder);
}