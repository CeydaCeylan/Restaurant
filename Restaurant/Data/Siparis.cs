using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class Siparis
{
    public int Id { get; set; }

    public DateTime? Tarih { get; set; }

    public int? Tutar { get; set; }

    public string? OdemeDurum { get; set; }

    public string? Not { get; set; }
    
    public int? YorumId { get; set; }

    public int? AdresId { get; set; }

	public bool? Gorunurluk { get; set; }

	public ICollection<Durum> Durumlars { get; set; } = new List<Durum>();

    public Yorum? Yorum { get; set; }

    public Adres? Adres { get; set; }

    public ICollection<TeslimatSiparis> TeslimatSiparislers { get; set; } = new List<TeslimatSiparis>();

    public ICollection<Odeme> Odemeler { get; set; } = new List<Odeme>();

    public ICollection<SiparisMenu> SiparisMenuler { get; set; } = new List<SiparisMenu>();

    public ICollection<SiparisUrun> SiparisUrunler { get; set; } = new List<SiparisUrun>();

}
