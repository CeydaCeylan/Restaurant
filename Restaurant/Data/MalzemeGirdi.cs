using System;
using System.Collections.Generic;

namespace Restaurant.Data;

public partial class MalzemeGirdi
{

	public int Id { get; set; }

	public int? GirdiId { get; set; }

    public int? MalzemeId { get; set; }

    public StokGirdi? Girdi { get; set; }

    public Malzeme? Malzeme { get; set; }
}
