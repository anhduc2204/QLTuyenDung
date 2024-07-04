using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTuyenDung.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_NguoiDung",
                columns: table => new
                {
                    iMaND = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sTenND = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sSDT = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    dNgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    sGioiTinh = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_NguoiDung", x => x.iMaND);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TaiKhoan",
                columns: table => new
                {
                    iMaTaiKhoan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sTaiKhoan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sMatKhau = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaND = table.Column<int>(type: "int", nullable: false),
                    iMaND = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TaiKhoan", x => x.iMaTaiKhoan);
                    table.ForeignKey(
                        name: "FK_tbl_TaiKhoan_tbl_NguoiDung_iMaND",
                        column: x => x.iMaND,
                        principalTable: "tbl_NguoiDung",
                        principalColumn: "iMaND",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TaiKhoan_iMaND",
                table: "tbl_TaiKhoan",
                column: "iMaND");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_TaiKhoan");

            migrationBuilder.DropTable(
                name: "tbl_NguoiDung");
        }
    }
}
