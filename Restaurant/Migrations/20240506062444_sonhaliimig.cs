using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class sonhaliimig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MusteriId",
                table: "Rezervasyonlar",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tur",
                table: "Kategoriler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Kategoriler",
                type: "varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_MusteriId",
                table: "Rezervasyonlar",
                column: "MusteriId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervasyonlar_Musteriler_MusteriId",
                table: "Rezervasyonlar",
                column: "MusteriId",
                principalTable: "Musteriler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervasyonlar_Musteriler_MusteriId",
                table: "Rezervasyonlar");

            migrationBuilder.DropIndex(
                name: "IX_Rezervasyonlar_MusteriId",
                table: "Rezervasyonlar");

            migrationBuilder.DropColumn(
                name: "MusteriId",
                table: "Rezervasyonlar");

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "Tur",
                keyValue: null,
                column: "Tur",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Tur",
                table: "Kategoriler",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Kategoriler",
                keyColumn: "Ad",
                keyValue: null,
                column: "Ad",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Kategoriler",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(30)",
                oldMaxLength: 30,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
