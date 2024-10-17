using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class HangXe
{
    public string CateId { get; set; } = null!;

    public string? TenHang { get; set; }

    public virtual ICollection<MauXe> MauXes { get; set; } = new List<MauXe>();
}
