using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class Yorum
{
    public int Id { get; set; }

    public string? Baslik { get; set; }

    public string? Icerik { get; set; }

    public DateOnly? Tarih { get; set; }

    public int? Puan { get; set; }

    public int? Begenme { get; set; }

    public int? Durum { get; set; }
    // Onaylanma Durumu
    // 1 Onaylanmamış,2 Onaylandı,3 Kullanıcı yorumu sildi, 4 Admin yorumu sildi.

    public int? MusteriId { get; set; }
	public bool? Gorunurluk { get; set; }

	public Musteri? Musteri { get; set; }

    public ICollection<Siparis> Siparislers { get; set; } = new List<Siparis>();
}
