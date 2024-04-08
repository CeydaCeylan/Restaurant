using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class Teslimat
{
    public int Id { get; set; }

    public DateTime? Cıkıs { get; set; }

    public DateTime? Varis { get; set; }

    public string? OdemeDurum { get; set; }

    public string? TeslimDurum { get; set; }

    public int? PersonelId { get; set; }
	public bool? Gorunurluk { get; set; }

	public Personel? Personel { get; set; }

    public ICollection<TeslimatSiparis> TeslimatSiparislers { get; set; } = new List<TeslimatSiparis>();
}
