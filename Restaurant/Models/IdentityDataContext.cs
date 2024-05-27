using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;

namespace Restaurant.Models
{
	public class IdentityDataContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
		{

		}

		public DbSet<Adres> Adresler { get; set; }

		public DbSet<Bildirim> Bildirimler { get; set; }

		public DbSet<Durum> Durumlar { get; set; }

		public DbSet<Kampanya> Kampanyalar { get; set; }

		public DbSet<Kasa> Kasalar { get; set; }

		public DbSet<Kategori> Kategoriler { get; set; }

		public DbSet<Malzeme> Malzemeler { get; set; }

		public DbSet<Masa> Masalar { get; set; }

		public DbSet<MasaOzellik> MasaOzellikler { get; set; }

		public DbSet<MasaRezervasyon> MasaRezervasyonlar { get; set; }

		public DbSet<MasaSiparis> MasaSiparisler { get; set; }

		public DbSet<Menu> Menuler { get; set; }

		public DbSet<MenuUrun> MenuUrunler { get; set; }

		public DbSet<Musteri> Musteriler { get; set; }

		public DbSet<Mutfak> Mutfaklar { get; set; }

		public DbSet<Ozellik> Ozellikler { get; set; }

		public DbSet<Personel> Personeller { get; set; }

		public DbSet<Rezervasyon> Rezervasyonlar { get; set; }

		public DbSet<Rol> Roller { get; set; }

		public DbSet<Siparis> Siparisler { get; set; }

		public DbSet<SiparisMenu> SiparisMenuler { get; set; }

		public DbSet<SiparisUrun> SiparisUrunler { get; set; }

		public DbSet<StokGirdi> StokGirdiler { get; set; }
        public DbSet<StokCikti> StokCiktilar { get; set; }


        public DbSet<Stok> Stoklar { get; set; }

		public DbSet<Tedarikci> Tedarikciler { get; set; }

		public DbSet<TeslimatAdres> TeslimatAdresler { get; set; }

		public DbSet<Teslimat> Teslimatlar { get; set; }

		public DbSet<TeslimatSiparis> TeslimatSiparisler { get; set; }

		public DbSet<Urun> Urunler { get; set; }

		public DbSet<UrunMalzeme> UrunMalzemeler { get; set; }

		public DbSet<Yorum> Yorumlar { get; set; }

        public DbSet<Odeme> Odemeler { get; set; }

        public DbSet<KayitsizMusteri> KayitsizMusteriler { get; set; }

		//Veritabanında decimalleri virgülden sonra 2 basamak göstermek için.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

			builder.Entity<Personel>
				().Property(p => p.Maas)
				.HasColumnType("decimal (10,2)");

            builder.Entity<Malzeme>
                ().Property(m => m.Fiyat)
                .HasColumnType("decimal (10,2)");

            builder.Entity<Urun>
               ().Property(u => u.Fiyat)
               .HasColumnType("decimal (10,2)");

            builder.Entity<Urun>
             ().Property(u => u.IndirimliFiyat)
             .HasColumnType("decimal (10,2)");

            builder.Entity<Menu>
              ().Property(u => u.Fiyat)
              .HasColumnType("decimal (10,2)");

            builder.Entity<Menu>
             ().Property(u => u.IndirimliFiyat)
             .HasColumnType("decimal (10,2)");

            builder.Entity<MasaSiparis>
             ().Property(u => u.Tutar)
             .HasColumnType("decimal (10,2)");
        }
    }
}
