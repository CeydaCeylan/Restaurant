using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Personel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Ad { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Soyad { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Eposta { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "*Telefon numarası 11 karakter olmalıdır")]
    [RegularExpression(@"^\d+$", ErrorMessage = "*Sadece sayısal değerler kabul edilir")]
    public string? Telefon { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public decimal? Maas { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public DateOnly? DogumTarihi { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public DateOnly? BaslamaTarihi { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public bool? Cinsiyet { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? PersonelParola { get; set; }

    //[Required(ErrorMessage = "*Zorunlu Alan")]

    public string? PersonelFotograf { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? Adres {  get; set; }
    public int? RolId { get; set; }
    public Rol? Rol { get; set; }

    public bool? Gorunurluk { get; set; }

    public ICollection<Bildirim> Bildirimlers { get; set; } = new List<Bildirim>();

    public ICollection<Masa> Masalars { get; set; } = new List<Masa>();


    public ICollection<Teslimat> Teslimatlars { get; set; } = new List<Teslimat>();

}
