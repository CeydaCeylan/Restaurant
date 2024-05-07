using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Kategori
{
    public int Id { get; set; }
    [Required(ErrorMessage = "*Zorunlu Alan")]
    [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
    public string? Ad { get; set; }
    public string? Tur { get; set; }
	public bool? Gorunurluk { get; set; }

}
