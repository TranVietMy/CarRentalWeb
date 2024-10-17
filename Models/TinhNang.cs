using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class TinhNang
{
    public string FeatId { get; set; } = null!;

    public string? TenTinhNang { get; set; }

    public string? FeatImg { get; set; }

    public virtual ICollection<XeThue> Cars { get; set; } = new List<XeThue>();
}
