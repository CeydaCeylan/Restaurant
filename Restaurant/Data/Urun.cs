using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Urun
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Ad { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Acıklama { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Detay { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public decimal? Fiyat { get; set; }

    public string? Fotograf { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Aktif { get; set; }

    public decimal? IndirimliFiyat { get; set; }

    public int? IndirimYuzdesi { get; set; }

    public DateOnly? IndirimTarihi {  get; set; }
    public int? KategoriId { get; set; }
    public Kategori? Kategori { get; set; }
	public bool? Gorunurluk { get; set; }

}
