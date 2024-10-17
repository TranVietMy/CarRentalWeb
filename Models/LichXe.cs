using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class LichXe
{
    public string UnValidId { get; set; } = null!;

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public string? MoTa { get; set; }

    public string? CarId { get; set; }

    public virtual XeThue? Car { get; set; }
}
