using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Menu
{
    public int Id { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? Ad { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? Aciklama { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Lütfen sadece sayısal bir değer girin.")]
    public decimal? Fiyat { get; set; }
    public string? Fotograf { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public bool? Aktif { get; set; }
	public bool? Gorunurluk { get; set; }

	public decimal? IndirimliFiyat { get; set; }

    public int? IndirimYuzdesi { get; set; }

    public DateOnly? IndirimTarihi { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    public int KategoriId { get; set; }

    public Kategori? Kategori { get; set; }

}
