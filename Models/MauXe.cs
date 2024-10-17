using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class MauXe
{
    public string ModelId { get; set; } = null!;

    public string? TenMau { get; set; }

    public string? CateId { get; set; }

    public virtual HangXe? Cate { get; set; }

    public virtual ICollection<XeThue> XeThues { get; set; } = new List<XeThue>();
}
