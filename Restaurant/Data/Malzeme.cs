﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Malzeme
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Ad { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Turu { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Lütfen sadece sayısal bir değer girin.")]

    public decimal? Fiyat { get; set; }
	public bool? Gorunurluk { get; set; }

    public int? StokId { get; set; }

    public Stok? Stok { get; set; }

    public ICollection<UrunMalzeme> UrunMalzemeler { get; set; } = new List<UrunMalzeme>();

}
