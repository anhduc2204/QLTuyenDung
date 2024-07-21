using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTuyenDung.Migrations
{
    public partial class AddAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_ThongBao",
                columns: table => new
                {
                    iMaTB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sToEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sFromEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sTieuDe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sNoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iMaND = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ThongBao", x => x.iMaTB);
                    table.ForeignKey(
                        name: "FK_tbl_ThongBao_tbl_NguoiDung_iMaND",
                        column: x => x.iMaND,
                        principalTable: "tbl_NguoiDung",
                        principalColumn: "iMaND",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ViecLam",
                columns: table => new
                {
                    iMaViecLam = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sTieuDe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sMota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fMucLuong = table.Column<double>(type: "float", nullable: false),
                    dNgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dNgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bTrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ViecLam", x => x.iMaViecLam);
                });

            migrationBuilder.CreateTable(
                name: "tbl_DonUngTuyen",
                columns: table => new
                {
                    iMaDon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iMaViecLam = table.Column<int>(type: "int", nullable: false),
                    sMoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    iMaND = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_DonUngTuyen", x => x.iMaDon);
                    table.ForeignKey(
                        name: "FK_tbl_DonUngTuyen_tbl_NguoiDung_iMaND",
                        column: x => x.iMaND,
                        principalTable: "tbl_NguoiDung",
                        principalColumn: "iMaND",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_DonUngTuyen_tbl_ViecLam_iMaViecLam",
                        column: x => x.iMaViecLam,
                        principalTable: "tbl_ViecLam",
                        principalColumn: "iMaViecLam",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DonUngTuyen_iMaND",
                table: "tbl_DonUngTuyen",
                column: "iMaND");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_DonUngTuyen_iMaViecLam",
                table: "tbl_DonUngTuyen",
                column: "iMaViecLam");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ThongBao_iMaND",
                table: "tbl_ThongBao",
                column: "iMaND");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_DonUngTuyen");

            migrationBuilder.DropTable(
                name: "tbl_ThongBao");

            migrationBuilder.DropTable(
                name: "tbl_ViecLam");
        }
    }
}
