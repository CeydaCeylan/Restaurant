using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class StokGirdi
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Lütfen sadece sayısal bir değer girin.")]

    public int? Miktar { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Lütfen sadece sayısal bir değer girin.")]

    public int? AlısFiyati { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public DateTime? Tarih { get; set; }

    public bool? Gorunurluk { get; set; }

    public int? TedarikciId { get; set; }

    public int? MalzemeId { get; set; }

    public Malzeme? Malzeme { get; set; }

    public Tedarikci? Tedarikci { get; set; }
}
