﻿// <auto-generated />
using System;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.Migrations
{
    [DbContext(typeof(QuanLyXeThueContext))]
    [Migration("20241121080650_UpdateNgayThueToDateTime")]
    partial class UpdateNgayThueToDateTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRental.Models.DichVu", b =>
                {
                    b.Property<string>("IdDv")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("IdDV")
                        .IsFixedLength();

                    b.Property<double?>("GiaDv")
                        .HasColumnType("float")
                        .HasColumnName("GiaDV");

                    b.Property<string>("RentalId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("RentalID")
                        .IsFixedLength();

                    b.Property<int?>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("TenDv")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("TenDV");

                    b.Property<double?>("TongTien")
                        .HasColumnType("float");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDv")
                        .HasName("PK__DichVu__B77398B41BF182B2");

                    b.HasIndex("RentalId");

                    b.ToTable("DichVu", null, t =>
                        {
                            t.HasTrigger("UpdateTongTien");

                            t.HasTrigger("UpdateTongTienHopDongFromDichVu");

                            t.HasTrigger("UpdateTongTienHopDongFromDichVu2");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("CarRental.Models.HangXe", b =>
                {
                    b.Property<string>("CateId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("CateID")
                        .IsFixedLength();

                    b.Property<string>("TenHang")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CateId")
                        .HasName("PK__HangXe__27638D74505E6F54");

                    b.ToTable("HangXe", (string)null);
                });

            modelBuilder.Entity("CarRental.Models.HopDong", b =>
                {
                    b.Property<string>("RentalId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("RentalID")
                        .IsFixedLength();

                    b.Property<string>("CarId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("CarID")
                        .IsFixedLength();

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayThue")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhuongThucThue")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SttGiaoXe")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SttNhanXe")
                        .HasColumnType("int");

                    b.Property<double?>("TongChiPhi")
                        .HasColumnType("float");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("UserID")
                        .IsFixedLength();

                    b.HasKey("RentalId")
                        .HasName("PK__HopDong__9700596331C5135F");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("HopDong", null, t =>
                        {
                            t.HasTrigger("UpdateTongTienHopDong");
                        });

                    b.HasAnnotation("SqlServer:UseSqlOutputClause", false);
                });

            modelBuilder.Entity("CarRental.Models.LichXe", b =>
                {
                    b.Property<string>("UnValidId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("UnValidID")
                        .IsFixedLength();

                    b.Property<string>("CarId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("CarID")
                        .IsFixedLength();

                    b.Property<string>("MoTa")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateOnly?>("NgayBatDau")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("NgayKetThuc")
                        .HasColumnType("date");

                    b.HasKey("UnValidId")
                        .HasName("PK__LichXe__C249404C17783952");

                    b.HasIndex("CarId");

                    b.ToTable("LichXe", (string)null);
                });

            modelBuilder.Entity("CarRental.Models.MauXe", b =>
                {
                    b.Property<string>("ModelId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("ModelID")
                        .IsFixedLength();

                    b.Property<string>("CateId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("CateID")
                        .IsFixedLength();

                    b.Property<string>("TenMau")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ModelId")
                        .HasName("PK__MauXe__E8D7A1CC9A6DB572");

                    b.HasIndex("CateId");

                    b.ToTable("MauXe", (string)null);
                });

            modelBuilder.Entity("CarRental.Models.Owner", b =>
                {
                    b.Property<string>("OwnId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("OwnID")
                        .IsFixedLength();

                    b.Property<string>("Cccd")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("CCCD");

                    b.Property<string>("UserId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("UserID")
                        .IsFixedLength();

                    b.HasKey("OwnId")
                        .HasName("PK__Owner__7DD3889526EE2F06");

                    b.HasIndex(new[] { "UserId" }, "UQ_Owner_UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("Owner", (string)null);
                });

            modelBuilder.Entity("CarRental.Models.TinhNang", b =>
                {
                    b.Property<string>("FeatId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("FeatID")
                        .IsFixedLength();

                    b.Property<string>("FeatImg")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TenTinhNang")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("FeatId")
                        .HasName("PK__TinhNang__D53F25EE966536AD");

                    b.ToTable("TinhNang", (string)null);
                });

            modelBuilder.Entity("CarRental.Models.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("UserID")
                        .IsFixedLength();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("GiayPhepLx")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("GiayPhepLX");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("char(10)")
                        .IsFixedLength();

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId")
                        .HasName("PK__Users__1788CCAC49F1C1AD");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarRental.Models.XeImg", b =>
                {
                    b.Property<int>("ImgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ImgID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImgId"));

                    b.Property<string>("CarId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("CarID")
                        .IsFixedLength();

                    b.Property<string>("Img")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("ImgId")
                        .HasName("PK__XeImg__352F54136F254822");

                    b.HasIndex("CarId");

                    b.ToTable("XeImg", (string)null);
                });

            modelBuilder.Entity("CarRental.Models.XeThue", b =>
                {
                    b.Property<string>("CarId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("CarID")
                        .IsFixedLength();

                    b.Property<string>("Avatar")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DiaDiem")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<double?>("GiaThueGio")
                        .HasColumnType("float");

                    b.Property<double?>("GiaThueNgay")
                        .HasColumnType("float");

                    b.Property<string>("Loai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MoTa")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ModelId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("ModelID")
                        .IsFixedLength();

                    b.Property<string>("NhienLieu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OwnId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("OwnID")
                        .IsFixedLength();

                    b.Property<int?>("SoGhe")
                        .HasColumnType("int");

                    b.Property<string>("TenXe")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CarId")
                        .HasName("PK__XeThue__68A0340EC4437DF5");

                    b.HasIndex("ModelId");

                    b.HasIndex("OwnId");

                    b.ToTable("XeThue", (string)null);
                });

            modelBuilder.Entity("XeThueTinhNang", b =>
                {
                    b.Property<string>("CarId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("CarID")
                        .IsFixedLength();

                    b.Property<string>("FeatId")
                        .HasMaxLength(8)
                        .IsUnicode(false)
                        .HasColumnType("char(8)")
                        .HasColumnName("FeatID")
                        .IsFixedLength();

                    b.HasKey("CarId", "FeatId")
                        .HasName("PK__XeThue_T__95F3C6507029C406");

                    b.HasIndex("FeatId");

                    b.ToTable("XeThue_TinhNang", (string)null);
                });

            modelBuilder.Entity("CarRental.Models.DichVu", b =>
                {
                    b.HasOne("CarRental.Models.HopDong", "Rental")
                        .WithMany("DichVus")
                        .HasForeignKey("RentalId")
                        .HasConstraintName("FK__DichVu__RentalID__4CA06362");

                    b.Navigation("Rental");
                });

            modelBuilder.Entity("CarRental.Models.HopDong", b =>
                {
                    b.HasOne("CarRental.Models.XeThue", "Car")
                        .WithMany("HopDongs")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK__HopDong__CarID__49C3F6B7");

                    b.HasOne("CarRental.Models.User", "User")
                        .WithMany("HopDongs")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__HopDong__UserID__48CFD27E");

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRental.Models.LichXe", b =>
                {
                    b.HasOne("CarRental.Models.XeThue", "Car")
                        .WithMany("LichXes")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK__LichXe__CarID__45F365D3");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarRental.Models.MauXe", b =>
                {
                    b.HasOne("CarRental.Models.HangXe", "Cate")
                        .WithMany("MauXes")
                        .HasForeignKey("CateId")
                        .HasConstraintName("FK__MauXe__CateID__403A8C7D");

                    b.Navigation("Cate");
                });

            modelBuilder.Entity("CarRental.Models.Owner", b =>
                {
                    b.HasOne("CarRental.Models.User", "User")
                        .WithOne("Owner")
                        .HasForeignKey("CarRental.Models.Owner", "UserId")
                        .HasConstraintName("FK__Owner__UserID__398D8EEE");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarRental.Models.XeImg", b =>
                {
                    b.HasOne("CarRental.Models.XeThue", "Car")
                        .WithMany("XeImgs")
                        .HasForeignKey("CarId")
                        .HasConstraintName("FK__XeImg__CarID__60A75C0F");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarRental.Models.XeThue", b =>
                {
                    b.HasOne("CarRental.Models.MauXe", "Model")
                        .WithMany("XeThues")
                        .HasForeignKey("ModelId")
                        .HasConstraintName("FK_XeThue_MauXe");

                    b.HasOne("CarRental.Models.Owner", "Own")
                        .WithMany("XeThues")
                        .HasForeignKey("OwnId")
                        .HasConstraintName("FK__XeThue__OwnID__4316F928");

                    b.Navigation("Model");

                    b.Navigation("Own");
                });

            modelBuilder.Entity("XeThueTinhNang", b =>
                {
                    b.HasOne("CarRental.Models.XeThue", null)
                        .WithMany()
                        .HasForeignKey("CarId")
                        .IsRequired()
                        .HasConstraintName("FK__XeThue_Ti__CarID__5AEE82B9");

                    b.HasOne("CarRental.Models.TinhNang", null)
                        .WithMany()
                        .HasForeignKey("FeatId")
                        .IsRequired()
                        .HasConstraintName("FK__XeThue_Ti__FeatI__5BE2A6F2");
                });

            modelBuilder.Entity("CarRental.Models.HangXe", b =>
                {
                    b.Navigation("MauXes");
                });

            modelBuilder.Entity("CarRental.Models.HopDong", b =>
                {
                    b.Navigation("DichVus");
                });

            modelBuilder.Entity("CarRental.Models.MauXe", b =>
                {
                    b.Navigation("XeThues");
                });

            modelBuilder.Entity("CarRental.Models.Owner", b =>
                {
                    b.Navigation("XeThues");
                });

            modelBuilder.Entity("CarRental.Models.User", b =>
                {
                    b.Navigation("HopDongs");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CarRental.Models.XeThue", b =>
                {
                    b.Navigation("HopDongs");

                    b.Navigation("LichXes");

                    b.Navigation("XeImgs");
                });
#pragma warning restore 612, 618
        }
    }
}
