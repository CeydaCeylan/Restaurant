using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class MasaSiparis
{

	public int Id { get; set; }
    public decimal? Tutar { get; set; }

    public decimal? OdenenTutar { get; set; }
    public int? MasaId { get; set; }

	public int? MusteriId { get; set; }
    public int? SiparisId { get; set; }

	public bool? Gorunurluk { get; set; }

	public Masa? Masa { get; set; } = null!;

    public Siparis? Siparis { get; set; } = null!;

	public Musteri? Musteri { get; set; }
}
