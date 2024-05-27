using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Personel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Ad en az 3 karakter en fazla 30 karakter olmalıdır.")]
    public string? Ad { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Ad en az 3 karakter en fazla 30 karakter olmalıdır.")]
    public string? Soyad { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
    [DataType(DataType.EmailAddress)]
    public string? Eposta { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Telefon { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "Sadece sayısal değerler kabul edilir.")]
    [Range(0, double.MaxValue, ErrorMessage = "Maaş negatif olamaz.")]
    public decimal? Maas { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public DateOnly? DogumTarihi { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public DateOnly? BaslamaTarihi { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public bool? Cinsiyet { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Şifre en az 6 karakter uzunluğunda olmalı ve hem sayı hem de harf içermelidir.")]
    public string? PersonelParola { get; set; }

    public string? PersonelFotograf { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 karakter en fazla 50 karakter olmalıdır.")]

    public string? Adres {  get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]

    public int? RolId { get; set; }
    public Rol? Rol { get; set; }

    public bool? Gorunurluk { get; set; }

    public ICollection<Bildirim> Bildirimlers { get; set; } = new List<Bildirim>();

    public ICollection<Masa> Masalars { get; set; } = new List<Masa>();


    public ICollection<Teslimat> Teslimatlars { get; set; } = new List<Teslimat>();

}
