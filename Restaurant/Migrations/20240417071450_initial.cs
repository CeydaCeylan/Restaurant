using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Menuler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tur",
                table: "Kategoriler",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Menuler_KategoriId",
                table: "Menuler",
                column: "KategoriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menuler_Kategoriler_KategoriId",
                table: "Menuler",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menuler_Kategoriler_KategoriId",
                table: "Menuler");

            migrationBuilder.DropIndex(
                name: "IX_Menuler_KategoriId",
                table: "Menuler");

            migrationBuilder.DropColumn(
                name: "KategoriId",
                table: "Menuler");

            migrationBuilder.DropColumn(
                name: "Tur",
                table: "Kategoriler");
        }
    }
}
