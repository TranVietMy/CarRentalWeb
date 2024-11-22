using System.ComponentModel.DataAnnotations;
namespace CarRental.Models{
public class AddCarModel
{[Required(ErrorMessage = "Tên xe là bắt buộc.")]
    public string TenXe { get; set; }
    [Required(ErrorMessage = "Số ghế là bắt buộc.")]
    public int SoGhe { get; set; }
    [Required(ErrorMessage = "Loại xe là bắt buộc.")]
    public string Loai { get; set; }
    public string NhienLieu { get; set; }
    [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
    public string DiaDiem { get; set; }
    [Required(ErrorMessage = "Mô tả là bắt buộc.")]
    public string MoTa { get; set; }
    [Required(ErrorMessage = "Giá theo ngày là bắt buộc.")]
    public double GiaThueNgay { get; set; }
[Required(ErrorMessage = "Giá theo giờ là bắt buộc.")]
    public double GiaThueGio { get; set; }
    public string? ModelId { get; set; }
    [Required(ErrorMessage = "Avatar (URL ảnh) là bắt buộc.")]
        [Url(ErrorMessage = "Địa chỉ URL không hợp lệ.")]
    public string Avatar { get; set; }  
    public List<HangXe> HangXes { get; set; } = new List<HangXe>();
    // 
    public List<TinhNang> AllFeats { get; set; } =new List<TinhNang>();    // Các tính năng có thể chọn
    public List<string> SelectedFeats { get; set; }=new List<string>(); // Các tính năng đã chọn
    public List<string> AdditionalImages { get; set; }
}
}