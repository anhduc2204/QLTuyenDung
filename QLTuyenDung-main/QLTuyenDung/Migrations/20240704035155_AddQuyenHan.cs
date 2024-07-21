using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLTuyenDung.Migrations
{
    public partial class AddQuyenHan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaQuyen",
                table: "tbl_TaiKhoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "iMaQuyen",
                table: "tbl_TaiKhoan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tbl_QuyenHan",
                columns: table => new
                {
                    iMaQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sTenQuyen = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_QuyenHan", x => x.iMaQuyen);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_TaiKhoan_iMaQuyen",
                table: "tbl_TaiKhoan",
                column: "iMaQuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_TaiKhoan_tbl_QuyenHan_iMaQuyen",
                table: "tbl_TaiKhoan",
                column: "iMaQuyen",
                principalTable: "tbl_QuyenHan",
                principalColumn: "iMaQuyen",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_TaiKhoan_tbl_QuyenHan_iMaQuyen",
                table: "tbl_TaiKhoan");

            migrationBuilder.DropTable(
                name: "tbl_QuyenHan");

            migrationBuilder.DropIndex(
                name: "IX_tbl_TaiKhoan_iMaQuyen",
                table: "tbl_TaiKhoan");

            migrationBuilder.DropColumn(
                name: "MaQuyen",
                table: "tbl_TaiKhoan");

            migrationBuilder.DropColumn(
                name: "iMaQuyen",
                table: "tbl_TaiKhoan");
        }
    }
}
