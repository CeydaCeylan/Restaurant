using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class soruisareti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasaOzellikler_Masalar_MasaId",
                table: "MasaOzellikler");

            migrationBuilder.DropForeignKey(
                name: "FK_MasaOzellikler_Ozellikler_OzellikId",
                table: "MasaOzellikler");

            migrationBuilder.DropForeignKey(
                name: "FK_MasaRezervasyonlar_Masalar_MasaId",
                table: "MasaRezervasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_MasaRezervasyonlar_Rezervasyonlar_RezervasyonId",
                table: "MasaRezervasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuUrunler_Menuler_MenuId",
                table: "MenuUrunler");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuUrunler_Urunler_UrunId",
                table: "MenuUrunler");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunMalzemeler_Malzemeler_MalzemeId",
                table: "UrunMalzemeler");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunMalzemeler_Urunler_UrunId",
                table: "UrunMalzemeler");

            migrationBuilder.AlterColumn<int>(
                name: "UrunId",
                table: "UrunMalzemeler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MalzemeId",
                table: "UrunMalzemeler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MalzemeId",
                table: "Stoklar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UrunId",
                table: "MenuUrunler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuUrunler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RezervasyonId",
                table: "MasaRezervasyonlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MasaId",
                table: "MasaRezervasyonlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OzellikId",
                table: "MasaOzellikler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MasaId",
                table: "MasaOzellikler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MasaOzellikler_Masalar_MasaId",
                table: "MasaOzellikler",
                column: "MasaId",
                principalTable: "Masalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasaOzellikler_Ozellikler_OzellikId",
                table: "MasaOzellikler",
                column: "OzellikId",
                principalTable: "Ozellikler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasaRezervasyonlar_Masalar_MasaId",
                table: "MasaRezervasyonlar",
                column: "MasaId",
                principalTable: "Masalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasaRezervasyonlar_Rezervasyonlar_RezervasyonId",
                table: "MasaRezervasyonlar",
                column: "RezervasyonId",
                principalTable: "Rezervasyonlar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuUrunler_Menuler_MenuId",
                table: "MenuUrunler",
                column: "MenuId",
                principalTable: "Menuler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuUrunler_Urunler_UrunId",
                table: "MenuUrunler",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UrunMalzemeler_Malzemeler_MalzemeId",
                table: "UrunMalzemeler",
                column: "MalzemeId",
                principalTable: "Malzemeler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UrunMalzemeler_Urunler_UrunId",
                table: "UrunMalzemeler",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasaOzellikler_Masalar_MasaId",
                table: "MasaOzellikler");

            migrationBuilder.DropForeignKey(
                name: "FK_MasaOzellikler_Ozellikler_OzellikId",
                table: "MasaOzellikler");

            migrationBuilder.DropForeignKey(
                name: "FK_MasaRezervasyonlar_Masalar_MasaId",
                table: "MasaRezervasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_MasaRezervasyonlar_Rezervasyonlar_RezervasyonId",
                table: "MasaRezervasyonlar");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuUrunler_Menuler_MenuId",
                table: "MenuUrunler");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuUrunler_Urunler_UrunId",
                table: "MenuUrunler");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunMalzemeler_Malzemeler_MalzemeId",
                table: "UrunMalzemeler");

            migrationBuilder.DropForeignKey(
                name: "FK_UrunMalzemeler_Urunler_UrunId",
                table: "UrunMalzemeler");

            migrationBuilder.AlterColumn<int>(
                name: "UrunId",
                table: "UrunMalzemeler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MalzemeId",
                table: "UrunMalzemeler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MalzemeId",
                table: "Stoklar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UrunId",
                table: "MenuUrunler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "MenuUrunler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RezervasyonId",
                table: "MasaRezervasyonlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MasaId",
                table: "MasaRezervasyonlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OzellikId",
                table: "MasaOzellikler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MasaId",
                table: "MasaOzellikler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MasaOzellikler_Masalar_MasaId",
                table: "MasaOzellikler",
                column: "MasaId",
                principalTable: "Masalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasaOzellikler_Ozellikler_OzellikId",
                table: "MasaOzellikler",
                column: "OzellikId",
                principalTable: "Ozellikler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasaRezervasyonlar_Masalar_MasaId",
                table: "MasaRezervasyonlar",
                column: "MasaId",
                principalTable: "Masalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasaRezervasyonlar_Rezervasyonlar_RezervasyonId",
                table: "MasaRezervasyonlar",
                column: "RezervasyonId",
                principalTable: "Rezervasyonlar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuUrunler_Menuler_MenuId",
                table: "MenuUrunler",
                column: "MenuId",
                principalTable: "Menuler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuUrunler_Urunler_UrunId",
                table: "MenuUrunler",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrunMalzemeler_Malzemeler_MalzemeId",
                table: "UrunMalzemeler",
                column: "MalzemeId",
                principalTable: "Malzemeler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UrunMalzemeler_Urunler_UrunId",
                table: "UrunMalzemeler",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
