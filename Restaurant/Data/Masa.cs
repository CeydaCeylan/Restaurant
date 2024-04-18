﻿using Microsoft.AspNetCore.Mvc;
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

    public int? Kapasite { get; set; }

    public int? Tutar { get; set; }

    public int? OdenenTutar { get; set; }
	public bool? Gorunurluk { get; set; }

	public int? PersonelId { get; set; }

    public int? KategoriId { get; set; }

    public Kategori? Kategori { get; set; }

    public ICollection<Musteri> Musterilers { get; set; } = new List<Musteri>();

    public Personel? Personel { get; set; }
}
