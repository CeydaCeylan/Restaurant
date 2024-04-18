using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class yeniinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masalar_Kategoriler_KategoriId",
                table: "Masalar");

            migrationBuilder.AddColumn<int>(
                name: "Durum",
                table: "Yorumlar",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Masalar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Masalar_Kategoriler_KategoriId",
                table: "Masalar",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masalar_Kategoriler_KategoriId",
                table: "Masalar");

            migrationBuilder.DropColumn(
                name: "Durum",
                table: "Yorumlar");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Masalar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Masalar_Kategoriler_KategoriId",
                table: "Masalar",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
