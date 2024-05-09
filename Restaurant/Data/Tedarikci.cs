using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Tedarikci
{
    public int Id { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 karakter en fazla 50 karakter olmalıdır.")]

    public string? AdSoyad { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "En az 3 karakter en fazla 30 karakter olmalıdır.")]

    public string? Firma { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? Telefon { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
    public string? Eposta { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 karakter en fazla 50 karakter olmalıdır.")]

    public string? Adres { get; set; }
    public bool? Gorunurluk { get; set; }
    
    public ICollection<StokGirdi> StokGirdilers { get; set; } = new List<StokGirdi>();

    public ICollection<Stok> Stoklars { get; set; } = new List<Stok>();
}
