﻿using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class Siparis
{
    public int Id { get; set; }

    public DateOnly? Tarih { get; set; }

    public string? Adres { get; set; }

    public int? Tutar { get; set; }

    public string? OdemeDurum { get; set; }

    public string? OdemeTuru { get; set; }

    public string? Not { get; set; }
    
    public int? YorumId { get; set; }
    public int? KasaId { get; set; }

    public int? MutfakId { get; set; }

	public bool? Gorunurluk { get; set; }

	public ICollection<Durum> Durumlars { get; set; } = new List<Durum>();

    public Kasa? Kasa { get; set; }

    public Mutfak? Mutfak { get; set; }

    public Yorum? Yorum { get; set; }

    public ICollection<TeslimatSiparis> TeslimatSiparislers { get; set; } = new List<TeslimatSiparis>();

}
