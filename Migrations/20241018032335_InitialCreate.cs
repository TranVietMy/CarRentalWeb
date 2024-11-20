using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangXe",
                columns: table => new
                {
                    CateID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    TenHang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HangXe__27638D74505E6F54", x => x.CateID);
                });

            migrationBuilder.CreateTable(
                name: "TinhNang",
                columns: table => new
                {
                    FeatID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    TenTinhNang = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FeatImg = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TinhNang__D53F25EE966536AD", x => x.FeatID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GiayPhepLX = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CCAC49F1C1AD", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "MauXe",
                columns: table => new
                {
                    ModelID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    TenMau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CateID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__MauXe__E8D7A1CC9A6DB572", x => x.ModelID);
                    table.ForeignKey(
                        name: "FK__MauXe__CateID__403A8C7D",
                        column: x => x.CateID,
                        principalTable: "HangXe",
                        principalColumn: "CateID");
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    CCCD = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    UserID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Owner__7DD3889526EE2F06", x => x.OwnID);
                    table.ForeignKey(
                        name: "FK__Owner__UserID__398D8EEE",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "XeThue",
                columns: table => new
                {
                    CarID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    TenXe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SoGhe = table.Column<int>(type: "int", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NhienLieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DiaDiem = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OwnID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true),
                    ModelID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    GiaThueNgay = table.Column<double>(type: "float", nullable: true),
                    GiaThueGio = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__XeThue__68A0340EC4437DF5", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_XeThue_MauXe",
                        column: x => x.ModelID,
                        principalTable: "MauXe",
                        principalColumn: "ModelID");
                    table.ForeignKey(
                        name: "FK__XeThue__OwnID__4316F928",
                        column: x => x.OwnID,
                        principalTable: "Owner",
                        principalColumn: "OwnID");
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    RentalID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    NgayThue = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayKetThuc = table.Column<DateOnly>(type: "date", nullable: true),
                    TongChiPhi = table.Column<double>(type: "float", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SttGiaoXe = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SttNhanXe = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true),
                    CarID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true),
                    PhuongThucThue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HopDong__9700596331C5135F", x => x.RentalID);
                    table.ForeignKey(
                        name: "FK__HopDong__CarID__49C3F6B7",
                        column: x => x.CarID,
                        principalTable: "XeThue",
                        principalColumn: "CarID");
                    table.ForeignKey(
                        name: "FK__HopDong__UserID__48CFD27E",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "LichXe",
                columns: table => new
                {
                    UnValidID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    NgayBatDau = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayKetThuc = table.Column<DateOnly>(type: "date", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CarID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LichXe__C249404C17783952", x => x.UnValidID);
                    table.ForeignKey(
                        name: "FK__LichXe__CarID__45F365D3",
                        column: x => x.CarID,
                        principalTable: "XeThue",
                        principalColumn: "CarID");
                });

            migrationBuilder.CreateTable(
                name: "XeImg",
                columns: table => new
                {
                    ImgID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true),
                    Img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__XeImg__352F54136F254822", x => x.ImgID);
                    table.ForeignKey(
                        name: "FK__XeImg__CarID__60A75C0F",
                        column: x => x.CarID,
                        principalTable: "XeThue",
                        principalColumn: "CarID");
                });

            migrationBuilder.CreateTable(
                name: "XeThue_TinhNang",
                columns: table => new
                {
                    CarID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    FeatID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__XeThue_T__95F3C6507029C406", x => new { x.CarID, x.FeatID });
                    table.ForeignKey(
                        name: "FK__XeThue_Ti__CarID__5AEE82B9",
                        column: x => x.CarID,
                        principalTable: "XeThue",
                        principalColumn: "CarID");
                    table.ForeignKey(
                        name: "FK__XeThue_Ti__FeatI__5BE2A6F2",
                        column: x => x.FeatID,
                        principalTable: "TinhNang",
                        principalColumn: "FeatID");
                });

            migrationBuilder.CreateTable(
                name: "DichVu",
                columns: table => new
                {
                    IdDV = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: false),
                    TenDV = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GiaDV = table.Column<double>(type: "float", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    TongTien = table.Column<double>(type: "float", nullable: true),
                    RentalID = table.Column<string>(type: "char(8)", unicode: false, fixedLength: true, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DichVu__B77398B41BF182B2", x => x.IdDV);
                    table.ForeignKey(
                        name: "FK__DichVu__RentalID__4CA06362",
                        column: x => x.RentalID,
                        principalTable: "HopDong",
                        principalColumn: "RentalID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DichVu_RentalID",
                table: "DichVu",
                column: "RentalID");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_CarID",
                table: "HopDong",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_UserID",
                table: "HopDong",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_LichXe_CarID",
                table: "LichXe",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_MauXe_CateID",
                table: "MauXe",
                column: "CateID");

            migrationBuilder.CreateIndex(
                name: "UQ_Owner_UserID",
                table: "Owner",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_XeImg_CarID",
                table: "XeImg",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "IX_XeThue_ModelID",
                table: "XeThue",
                column: "ModelID");

            migrationBuilder.CreateIndex(
                name: "IX_XeThue_OwnID",
                table: "XeThue",
                column: "OwnID");

            migrationBuilder.CreateIndex(
                name: "IX_XeThue_TinhNang_FeatID",
                table: "XeThue_TinhNang",
                column: "FeatID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DichVu");

            migrationBuilder.DropTable(
                name: "LichXe");

            migrationBuilder.DropTable(
                name: "XeImg");

            migrationBuilder.DropTable(
                name: "XeThue_TinhNang");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "TinhNang");

            migrationBuilder.DropTable(
                name: "XeThue");

            migrationBuilder.DropTable(
                name: "MauXe");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "HangXe");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
