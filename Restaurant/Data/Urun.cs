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
    public int? Fiyat { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Fotograf { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Aktif { get; set; }

    public int? IndirimliFiyat { get; set; }

    public int? KategorId { get; set; }

    public Kategori? Kategori { get; set; }
	public bool? Gorunurluk { get; set; }

}
