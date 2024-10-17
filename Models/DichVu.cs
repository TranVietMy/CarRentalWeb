using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class DichVu
{
    public string IdDv { get; set; } = null!;

    public string? TenDv { get; set; }

    public double? GiaDv { get; set; }

    public string? TrangThai { get; set; }

    public int? SoLuong { get; set; }

    public double? TongTien { get; set; }

    public string? RentalId { get; set; }

    public virtual HopDong? Rental { get; set; }
}
