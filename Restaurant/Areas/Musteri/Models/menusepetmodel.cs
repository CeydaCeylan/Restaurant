

namespace Restaurant.Areas.Musteri.Models
{
    public class menusepetmodel
    {
        public int Id { get; set; }


        public string? Ad { get; set; }

        public string? Aciklama { get; set; }
        public decimal? Fiyat { get; set; }
        public string? Fotograf { get; set; }

        public bool? Aktif { get; set; }
        public bool? Gorunurluk { get; set; }

        public decimal? IndirimliFiyat { get; set; }

        public int? IndirimYuzdesi { get; set; }

        public DateOnly? IndirimTarihi { get; set; }
        public int KategoriId { get; set; }

        public int Tur { get; set; }

    }
}
