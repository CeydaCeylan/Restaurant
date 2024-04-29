using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Odeme

{
    public int Id { get; set; }

    public int Tur { get; set; }

    public decimal Tutar { get; set; }

    public int SiparisId { get; set; }

    public Siparis? Siparis { get; set;}
}
