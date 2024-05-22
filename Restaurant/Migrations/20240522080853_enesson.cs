using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class enesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masalar_Kategoriler_KategoriId",
                table: "Masalar");

            migrationBuilder.DropForeignKey(
                name: "FK_MasaSiparisler_Masalar_MasaId",
                table: "MasaSiparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_MasaSiparisler_Siparisler_SiparisId",
                table: "MasaSiparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Roller_RolId",
                table: "Personeller");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Adresler_AdresId",
                table: "Siparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisMenuler_Menuler_MenuId",
                table: "SiparisMenuler");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisMenuler_Siparisler_SiparisId",
                table: "SiparisMenuler");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisUrunler_Siparisler_SiparisId",
                table: "SiparisUrunler");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisUrunler_Urunler_UrunId",
                table: "SiparisUrunler");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Kategoriler_KategoriId",
                table: "Urunler");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Urunler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UrunId",
                table: "SiparisUrunler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SiparisId",
                table: "SiparisUrunler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SiparisId",
                table: "SiparisMenuler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "SiparisMenuler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Siparisler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Onay",
                table: "Rezervasyonlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SiparisId",
                table: "MasaSiparisler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MasaId",
                table: "MasaSiparisler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Masalar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Masalar_Kategoriler_KategoriId",
                table: "Masalar",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasaSiparisler_Masalar_MasaId",
                table: "MasaSiparisler",
                column: "MasaId",
                principalTable: "Masalar",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasaSiparisler_Siparisler_SiparisId",
                table: "MasaSiparisler",
                column: "SiparisId",
                principalTable: "Siparisler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Roller_RolId",
                table: "Personeller",
                column: "RolId",
                principalTable: "Roller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Adresler_AdresId",
                table: "Siparisler",
                column: "AdresId",
                principalTable: "Adresler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisMenuler_Menuler_MenuId",
                table: "SiparisMenuler",
                column: "MenuId",
                principalTable: "Menuler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisMenuler_Siparisler_SiparisId",
                table: "SiparisMenuler",
                column: "SiparisId",
                principalTable: "Siparisler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisUrunler_Siparisler_SiparisId",
                table: "SiparisUrunler",
                column: "SiparisId",
                principalTable: "Siparisler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisUrunler_Urunler_UrunId",
                table: "SiparisUrunler",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Kategoriler_KategoriId",
                table: "Urunler",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masalar_Kategoriler_KategoriId",
                table: "Masalar");

            migrationBuilder.DropForeignKey(
                name: "FK_MasaSiparisler_Masalar_MasaId",
                table: "MasaSiparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_MasaSiparisler_Siparisler_SiparisId",
                table: "MasaSiparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Roller_RolId",
                table: "Personeller");

            migrationBuilder.DropForeignKey(
                name: "FK_Siparisler_Adresler_AdresId",
                table: "Siparisler");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisMenuler_Menuler_MenuId",
                table: "SiparisMenuler");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisMenuler_Siparisler_SiparisId",
                table: "SiparisMenuler");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisUrunler_Siparisler_SiparisId",
                table: "SiparisUrunler");

            migrationBuilder.DropForeignKey(
                name: "FK_SiparisUrunler_Urunler_UrunId",
                table: "SiparisUrunler");

            migrationBuilder.DropForeignKey(
                name: "FK_Urunler_Kategoriler_KategoriId",
                table: "Urunler");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Urunler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "UrunId",
                table: "SiparisUrunler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SiparisId",
                table: "SiparisUrunler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SiparisId",
                table: "SiparisMenuler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MenuId",
                table: "SiparisMenuler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdresId",
                table: "Siparisler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Onay",
                table: "Rezervasyonlar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RolId",
                table: "Personeller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SiparisId",
                table: "MasaSiparisler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MasaId",
                table: "MasaSiparisler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KategoriId",
                table: "Masalar",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Tur",
                table: "Kategoriler",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Masalar_Kategoriler_KategoriId",
                table: "Masalar",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MasaSiparisler_Masalar_MasaId",
                table: "MasaSiparisler",
                column: "MasaId",
                principalTable: "Masalar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MasaSiparisler_Siparisler_SiparisId",
                table: "MasaSiparisler",
                column: "SiparisId",
                principalTable: "Siparisler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Roller_RolId",
                table: "Personeller",
                column: "RolId",
                principalTable: "Roller",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Siparisler_Adresler_AdresId",
                table: "Siparisler",
                column: "AdresId",
                principalTable: "Adresler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisMenuler_Menuler_MenuId",
                table: "SiparisMenuler",
                column: "MenuId",
                principalTable: "Menuler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisMenuler_Siparisler_SiparisId",
                table: "SiparisMenuler",
                column: "SiparisId",
                principalTable: "Siparisler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisUrunler_Siparisler_SiparisId",
                table: "SiparisUrunler",
                column: "SiparisId",
                principalTable: "Siparisler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiparisUrunler_Urunler_UrunId",
                table: "SiparisUrunler",
                column: "UrunId",
                principalTable: "Urunler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urunler_Kategoriler_KategoriId",
                table: "Urunler",
                column: "KategoriId",
                principalTable: "Kategoriler",
                principalColumn: "Id");
        }
    }
}
