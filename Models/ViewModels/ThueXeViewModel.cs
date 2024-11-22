using System.ComponentModel.DataAnnotations;
namespace CarRental.Models{
public class ThueXeViewModel
{
    public string CarId { get; set; }
    [Required(ErrorMessage = "Phương thức thuê là bắt buộc.")]
        public string PhuongThucThue { get; set; }

        [Required(ErrorMessage = "Ngày thuê là bắt buộc.")]
        public DateTime NgayThue { get; set; }

        [Required(ErrorMessage = "Ngày kết thúc là bắt buộc.")]
        public DateTime? NgayKetThuc { get; set; }

        [Required(ErrorMessage = "Số giờ thuê là bắt buộc.")]
        public int SoGioThue { get; set; }
    public double PhiDatCho { get; set; }
    public double PhiThueXe { get; set; }
    public decimal TongPhi { get; set; }
    public string TenXe { get; set; }
    public int SoGhe { get; set; }
    public string Loai { get; set; }
    public string NhienLieu { get; set; }
    public string DiaDiem { get; set; }
    public string MoTa { get; set; }
    public double? GiaThueNgay { get; set; }
    public double? GiaThueGio { get; set; }
    public string Avatar { get; set; }
}
}