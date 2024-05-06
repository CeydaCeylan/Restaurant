using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Stok
{
    public int Id { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Lütfen sadece sayısal bir değer girin.")]
    public int? Miktar { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Lütfen sadece sayısal bir değer girin.")]

    public int? MinStok { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    [RegularExpression(@"^\d+$", ErrorMessage = "Lütfen sadece sayısal bir değer girin.")]

    public int? MaxStok { get; set; }

    public int MalzemeId { get; set; }

    public int? TedarikciId { get; set; }
	public bool? Gorunurluk { get; set; }

	public ICollection<Malzeme> Malzemelers { get; set; } = new List<Malzeme>();

    public Tedarikci? Tedarikci { get; set; }
}
