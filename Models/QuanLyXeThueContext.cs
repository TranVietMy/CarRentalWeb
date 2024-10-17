using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class QuanLyXeThueContext : DbContext
{
    public QuanLyXeThueContext()
    {
    }

    public QuanLyXeThueContext(DbContextOptions<QuanLyXeThueContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<HangXe> HangXes { get; set; }

    public virtual DbSet<HopDong> HopDongs { get; set; }

    public virtual DbSet<LichXe> LichXes { get; set; }

    public virtual DbSet<MauXe> MauXes { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<TinhNang> TinhNangs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<XeImg> XeImgs { get; set; }

    public virtual DbSet<XeThue> XeThues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-JSHBO3GB\\MSSQLSERVERS;Database=QuanLyXeThue;User Id=sa;Password=tranvietmy;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.IdDv).HasName("PK__DichVu__B77398B41BF182B2");

            entity.ToTable("DichVu", tb =>
                {
                    tb.HasTrigger("UpdateTongTien");
                    tb.HasTrigger("UpdateTongTienHopDongFromDichVu");
                    tb.HasTrigger("UpdateTongTienHopDongFromDichVu2");
                });

            entity.Property(e => e.IdDv)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("IdDV");
            entity.Property(e => e.GiaDv).HasColumnName("GiaDV");
            entity.Property(e => e.RentalId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RentalID");
            entity.Property(e => e.TenDv)
                .HasMaxLength(100)
                .HasColumnName("TenDV");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.Rental).WithMany(p => p.DichVus)
                .HasForeignKey(d => d.RentalId)
                .HasConstraintName("FK__DichVu__RentalID__4CA06362");
        });

        modelBuilder.Entity<HangXe>(entity =>
        {
            entity.HasKey(e => e.CateId).HasName("PK__HangXe__27638D74505E6F54");

            entity.ToTable("HangXe");

            entity.Property(e => e.CateId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CateID");
            entity.Property(e => e.TenHang).HasMaxLength(100);
        });

        modelBuilder.Entity<HopDong>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__HopDong__9700596331C5135F");

            entity.ToTable("HopDong", tb => tb.HasTrigger("UpdateTongTienHopDong"));

            entity.Property(e => e.RentalId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("RentalID");
            entity.Property(e => e.CarId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CarID");
            entity.Property(e => e.PhuongThucThue).HasMaxLength(50);
            entity.Property(e => e.SttGiaoXe).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(50);
            entity.Property(e => e.UserId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.Car).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__HopDong__CarID__49C3F6B7");

            entity.HasOne(d => d.User).WithMany(p => p.HopDongs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__HopDong__UserID__48CFD27E");
        });

        modelBuilder.Entity<LichXe>(entity =>
        {
            entity.HasKey(e => e.UnValidId).HasName("PK__LichXe__C249404C17783952");

            entity.ToTable("LichXe");

            entity.Property(e => e.UnValidId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UnValidID");
            entity.Property(e => e.CarId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CarID");
            entity.Property(e => e.MoTa).HasMaxLength(255);

            entity.HasOne(d => d.Car).WithMany(p => p.LichXes)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__LichXe__CarID__45F365D3");
        });

        modelBuilder.Entity<MauXe>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("PK__MauXe__E8D7A1CC9A6DB572");

            entity.ToTable("MauXe");

            entity.Property(e => e.ModelId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ModelID");
            entity.Property(e => e.CateId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CateID");
            entity.Property(e => e.TenMau).HasMaxLength(100);

            entity.HasOne(d => d.Cate).WithMany(p => p.MauXes)
                .HasForeignKey(d => d.CateId)
                .HasConstraintName("FK__MauXe__CateID__403A8C7D");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnId).HasName("PK__Owner__7DD3889526EE2F06");

            entity.ToTable("Owner");

            entity.HasIndex(e => e.UserId, "UQ_Owner_UserID").IsUnique();

            entity.Property(e => e.OwnId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OwnID");
            entity.Property(e => e.Cccd)
                .HasMaxLength(12)
                .HasColumnName("CCCD");
            entity.Property(e => e.UserId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithOne(p => p.Owner)
                .HasForeignKey<Owner>(d => d.UserId)
                .HasConstraintName("FK__Owner__UserID__398D8EEE");
        });

        modelBuilder.Entity<TinhNang>(entity =>
        {
            entity.HasKey(e => e.FeatId).HasName("PK__TinhNang__D53F25EE966536AD");

            entity.ToTable("TinhNang");

            entity.Property(e => e.FeatId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("FeatID");
            entity.Property(e => e.FeatImg).HasMaxLength(255);
            entity.Property(e => e.TenTinhNang).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC49F1C1AD");

            entity.Property(e => e.UserId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.GiayPhepLx)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("GiayPhepLX");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<XeImg>(entity =>
        {
            entity.HasKey(e => e.ImgId).HasName("PK__XeImg__352F54136F254822");

            entity.ToTable("XeImg");

            entity.Property(e => e.ImgId).HasColumnName("ImgID");
            entity.Property(e => e.CarId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CarID");
            entity.Property(e => e.Img).HasMaxLength(255);

            entity.HasOne(d => d.Car).WithMany(p => p.XeImgs)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__XeImg__CarID__60A75C0F");
        });

        modelBuilder.Entity<XeThue>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__XeThue__68A0340EC4437DF5");

            entity.ToTable("XeThue");

            entity.Property(e => e.CarId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CarID");
            entity.Property(e => e.Avatar).HasMaxLength(255);
            entity.Property(e => e.DiaDiem).HasMaxLength(255);
            entity.Property(e => e.Loai).HasMaxLength(50);
            entity.Property(e => e.MoTa).HasMaxLength(1000);
            entity.Property(e => e.ModelId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ModelID");
            entity.Property(e => e.NhienLieu).HasMaxLength(50);
            entity.Property(e => e.OwnId)
                .HasMaxLength(8)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("OwnID");
            entity.Property(e => e.TenXe).HasMaxLength(100);
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.Model).WithMany(p => p.XeThues)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FK_XeThue_MauXe");

            entity.HasOne(d => d.Own).WithMany(p => p.XeThues)
                .HasForeignKey(d => d.OwnId)
                .HasConstraintName("FK__XeThue__OwnID__4316F928");

            entity.HasMany(d => d.Feats).WithMany(p => p.Cars)
                .UsingEntity<Dictionary<string, object>>(
                    "XeThueTinhNang",
                    r => r.HasOne<TinhNang>().WithMany()
                        .HasForeignKey("FeatId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__XeThue_Ti__FeatI__5BE2A6F2"),
                    l => l.HasOne<XeThue>().WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__XeThue_Ti__CarID__5AEE82B9"),
                    j =>
                    {
                        j.HasKey("CarId", "FeatId").HasName("PK__XeThue_T__95F3C6507029C406");
                        j.ToTable("XeThue_TinhNang");
                        j.IndexerProperty<string>("CarId")
                            .HasMaxLength(8)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("CarID");
                        j.IndexerProperty<string>("FeatId")
                            .HasMaxLength(8)
                            .IsUnicode(false)
                            .IsFixedLength()
                            .HasColumnName("FeatID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
