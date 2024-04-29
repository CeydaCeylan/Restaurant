using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Data;

public partial class Ozellik
{
    public int Id { get; set; }

    [Required(ErrorMessage = "*Zorunlu Alan")]

    public string? Ad { get; set; }

	public bool? Gorunurluk { get; set; }
}
