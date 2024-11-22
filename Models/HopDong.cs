using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class HopDong
{
    public string RentalId { get; set; } = null!;

public DateTime? NgayThue { get; set; }
public DateTime? NgayKetThuc { get; set; }

    public double? TongChiPhi { get; set; }

    public string? TrangThai { get; set; }

    public string? SttGiaoXe { get; set; }

    public int? SttNhanXe { get; set; }

    public string? UserId { get; set; }

    public string? CarId { get; set; }

    public string? PhuongThucThue { get; set; }

    public virtual XeThue? Car { get; set; }

    public virtual ICollection<DichVu> DichVus { get; set; } = new List<DichVu>();

    public virtual User? User { get; set; }
}
