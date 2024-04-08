using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class Ozellik
{
    public int Id { get; set; }

    public string? Ad { get; set; }

	public bool? Gorunurluk { get; set; }
}
