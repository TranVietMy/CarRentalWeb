using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class User
{
    public string UserId { get; set; } = null!;

    public string? UserName { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public string? Address { get; set; }

    public string? GiayPhepLx { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual Owner? Owner { get; set; }
}
