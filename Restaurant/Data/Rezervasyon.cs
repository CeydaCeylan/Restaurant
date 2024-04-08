using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class Rezervasyon
{
    public int Id { get; set; }

    public DateOnly? Tarih { get; set; }

    public int? KisiSayisi { get; set; }

    public string? Talep { get; set; }

    public string? Onay { get; set; }

    public DateOnly? TalepTarihi { get; set; }

	public bool? Gorunurluk { get; set; }

}
