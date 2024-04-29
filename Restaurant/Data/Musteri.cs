using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class Musteri
{
    public int Id { get; set; }

    public string? Ad { get; set; }

    public string? Soyad { get; set; }

    public string? Eposta { get; set; }

    public string? Telefon { get; set; }

    public DateOnly? KayitTarihi { get; set; }

    public DateOnly? Dogumtarihi { get; set; }

	public bool? Gorunurluk { get; set; }

    public ICollection<Adres> Adresler { get; set; } = new List<Adres>();

    public ICollection<Bildirim> Bildirimlers { get; set; } = new List<Bildirim>();

    public  ICollection<Kampanya> Kampanyalars { get; set; } = new List<Kampanya>();

    public ICollection<TeslimatAdres> TeslimatAdreslers { get; set; } = new List<TeslimatAdres>();

    public ICollection<TeslimatSiparis> TeslimatSiparislers { get; set; } = new List<TeslimatSiparis>();

    public ICollection<Yorum> Yorumlars { get; set; } = new List<Yorum>();
}
