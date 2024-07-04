using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTuyenDung.Migrations
{
    public partial class UpdateTK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TaiKhoan_tbl_NguoiDung_iMaND",
                table: "tbl_TaiKhoan");

            migrationBuilder.DropIndex(
                name: "IX_tbl_TaiKhoan_iMaND",
                table: "tbl_TaiKhoan");

            migrationBuilder.DropColumn(
                name: "MaND",
                table: "tbl_TaiKhoan");

            migrationBuilder.DropColumn(
                name: "MaQuyen",
                table: "tbl_TaiKhoan");

            migrationBuilder.DropColumn(
                name: "iMaND",
                table: "tbl_TaiKhoan");

            migrationBuilder.AddColumn<int>(
                name: "iMaTaiKhoan",
                table: "tbl_NguoiDung",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_NguoiDung_iMaTaiKhoan",
                table: "tbl_NguoiDung",
                column: "iMaTaiKhoan",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_NguoiDung_tbl_TaiKhoan_iMaTaiKhoan",
                table: "tbl_NguoiDung",
                column: "iMaTaiKhoan",
                principalTable: "tbl_TaiKhoan",
                principalColumn: "iMaTaiKhoan",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_NguoiDung_tbl_TaiKhoan_iMaTaiKhoan",
                table: "tbl_NguoiDung");

            migrationBuilder.DropIndex(
                name: "IX_tbl_NguoiDung_iMaTaiKhoan",
                table: "tbl_NguoiDung");

            migrationBuilder.DropColumn(
                name: "iMaTaiKhoan",
                table: "tbl_NguoiDung");

            migrationBuilder.AddColumn<int>(
                name: "MaND",
                table: "tbl_TaiKhoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaQuyen",
                table: "tbl_TaiKhoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "iMaND",
                table: "tbl_TaiKhoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TaiKhoan_iMaND",
                table: "tbl_TaiKhoan",
                column: "iMaND");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TaiKhoan_tbl_NguoiDung_iMaND",
                table: "tbl_TaiKhoan",
                column: "iMaND",
                principalTable: "tbl_NguoiDung",
                principalColumn: "iMaND",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
