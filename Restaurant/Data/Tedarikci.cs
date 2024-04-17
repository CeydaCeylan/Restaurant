using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Tedarikci
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? AdSoyad { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? Firma { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? Telefon { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Eposta { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Adres { get; set; }
    public bool? Gorunurluk { get; set; }
    
    public ICollection<StokGirdi> StokGirdilers { get; set; } = new List<StokGirdi>();

    public ICollection<Stok> Stoklars { get; set; } = new List<Stok>();
}
