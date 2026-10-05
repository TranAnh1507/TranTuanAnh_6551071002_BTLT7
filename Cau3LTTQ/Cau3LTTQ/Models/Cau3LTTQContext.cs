using Microsoft.EntityFrameworkCore;

namespace Cau3LTTQ.Models;

public partial class Cau3LTTQContext : DbContext
{
    public Cau3LTTQContext()
    {
    }

    public Cau3LTTQContext(
        DbContextOptions<Cau3LTTQContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost\SQLEXPRESS;" +
                @"Database=Cau3LTTQ;" +
                @"Trusted_Connection=True;" +
                @"TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoaiPhong>(entity =>
        {
            entity.HasKey(e => e.MaLoai);

            entity.ToTable("LoaiPhong");

            entity.Property(e => e.TenLoai)
                .HasMaxLength(100);

            entity.Property(e => e.GiaMoiDem)
                .HasColumnType("decimal(18, 2)");

            entity.Property(e => e.MoTa)
                .HasMaxLength(255);
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong);

            entity.ToTable("Phong");

            entity.Property(e => e.SoPhong)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.TinhTrang)
                .HasMaxLength(20);

            entity.Property(e => e.HinhAnh)
                .HasMaxLength(255);

            entity.HasOne(d => d.MaLoaiNavigation)
                .WithMany(p => p.Phongs)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK_Phong_LoaiPhong");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(
        ModelBuilder modelBuilder);
}