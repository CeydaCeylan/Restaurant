using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class Adres
{
    public int Id { get; set; }

    public string? Il { get; set; }

    public string? Ilce { get; set; }

    public string? Koy { get; set; }

    public string? Mahalle { get; set; }

    public string? Sokak { get; set; }

    public int? No { get; set; }

    public string? Tarif { get; set; }

    public bool? Gorunurluk { get; set; }

    public int MusteriId { get; set; }

    public Musteri? Musteri { get; set; }

    //public virtual ICollection<Musteriler> Musterilers { get; set; } = new List<Musteriler>();

    //public virtual ICollection<Personeller> Personellers { get; set; } = new List<Personeller>();

    //public virtual ICollection<Tedarikci> Tedarikcilers { get; set; } = new List<Tedarikci>();

    //public virtual ICollection<Teslimatadresler> Teslimatadreslers { get; set; } = new List<Teslimatadresler>();
}
