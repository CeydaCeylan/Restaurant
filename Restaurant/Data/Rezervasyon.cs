using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Rezervasyon
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public DateOnly? Tarih { get; set; }

    public TimeOnly? BaslangicSaat { get; set; }

    public TimeOnly? BitisSaat { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]

    public int? KisiSayisi { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? Talep { get; set; }

    public int? Onay { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]

    public DateOnly? TalepTarihi { get; set; }

	public bool? Gorunurluk { get; set; }

    public int? KayitsizMusteriId { get; set; }

    public KayitsizMusteri? KayitsizMusteri { get; set; }
    public int? MusteriId { get; set; }

    public Musteri? Musteri { get; set; }

    public ICollection<MasaRezervasyon> MasaRezervasyonlar { get; set; } = new List<MasaRezervasyon>();

}
