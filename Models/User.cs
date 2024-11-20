using System;
using System.Collections.Generic;

namespace CarRental.Models;
using System.ComponentModel.DataAnnotations;
public partial class User
{
    public string UserId { get; set; } = null!;
    [Required(ErrorMessage = "Tên đăng nhập không được để trống.")]
    [StringLength(50, ErrorMessage = "Tên đăng nhập không được vượt quá 50 ký tự.")]
    public string? UserName { get; set; }
[Required(ErrorMessage = "Số điện thoại không được để trống.")]
    [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
    public string? Phone { get; set; }
[Required(ErrorMessage = "Mật khẩu không được để trống.")]
    [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên.")]
    public string? Password { get; set; }

    public string? Role { get; set; }
[Required(ErrorMessage = "Địa chỉ không được để trống.")]
    public string? Address { get; set; }

    public string? GiayPhepLx { get; set; }

    public virtual ICollection<HopDong> HopDongs { get; set; } = new List<HopDong>();

    public virtual Owner? Owner { get; set; }
}
