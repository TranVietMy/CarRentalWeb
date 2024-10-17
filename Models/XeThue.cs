using System;
using System.Collections.Generic;

namespace CarRental.Models;

public partial class XeThue
{
    public string CarId { get; set; } = null!;

    public string? TenXe { get; set; }

    public int? SoGhe { get; set; }

    public string? Loai { get; set; }

    public string? NhienLieu { get; set; }

    public string? TrangThai { get; set; }

    public string? DiaDiem { get; set; }

    public string? MoTa { get; set; }

    public string? OwnId { get; set; }

    public string? ModelId { get; set; }

    public string? Avatar { get; set; }

    public double? GiaThueNgay { get; set; }

    public double? GiaThueGio { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual ICollection<LichXe> LichXes { get; set; } = new List<LichXe>();

    public virtual MauXe? Model { get; set; }

    public virtual Owner? Own { get; set; }

    public virtual ICollection<XeImg> XeImgs { get; set; } = new List<XeImg>();

    public virtual ICollection<TinhNang> Feats { get; set; } = new List<TinhNang>();
}
