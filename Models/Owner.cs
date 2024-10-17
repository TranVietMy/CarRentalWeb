using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class Owner
{
    public string OwnId { get; set; } = null!;

    public string? Cccd { get; set; }

    public string? UserId { get; set; }

    public virtual User? User { get; set; }

    public virtual ICollection<XeThue> XeThues { get; set; } = new List<XeThue>();
}
