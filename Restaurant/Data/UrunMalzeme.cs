using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class UrunMalzeme
{
    public int Id { get; set; }

    public int? Miktar { get; set; }

    public bool? Secenek { get; set; }

    public bool? Gorunurluk { get; set; }

    public int MalzemeId { get; set; }

    public Malzeme? Malzeme { get; set; }

    public int UrunId { get; set; }

    public Urun? Urun { get; set; }
}
