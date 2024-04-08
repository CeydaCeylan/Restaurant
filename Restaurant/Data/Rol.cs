using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Rol
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]
    public string? Ad { get; set; }

	public bool? Gorunurluk { get; set; }

	public ICollection<Personel> Personellers { get; set; } = new List<Personel>();
}
