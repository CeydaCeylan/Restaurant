using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Masa
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? Kod { get; set; }

    public int? Durum { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Lütfen sadece sayısal bir değer girin.")]

    public int? Kapasite { get; set; }

    public string? Qr { get; set; }

	public bool? Gorunurluk { get; set; }

	public int? PersonelId { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public int? KategoriId { get; set; }

    public Kategori? Kategori { get; set; }

    public ICollection<MasaOzellik> MasaOzellikler { get; set; } = new List<MasaOzellik>();

    public Personel? Personel { get; set; }

    public ICollection<MasaRezervasyon> MasaRezervasyonlar { get; set; } = new List<MasaRezervasyon>();

}
