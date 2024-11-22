using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
namespace CarRental.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly QuanLyXeThueContext _quanLyXeThueContext;
 
    public HomeController(ILogger<HomeController> logger,QuanLyXeThueContext quanLyXeThueContext)
    {
        _logger = logger;
        _quanLyXeThueContext=quanLyXeThueContext;
    }


    public IActionResult Index()
    {var xeThues = _quanLyXeThueContext.XeThues.ToList();
    var viewModel = new CarViewModel
    {
        XeThues = xeThues
    };
    return View(viewModel);
    }
 public IActionResult ThueXe(string id)
    {
         var car = _quanLyXeThueContext.XeThues.FirstOrDefault(x=> x.CarId==id);  
          var model = new ThueXeViewModel
    {
        CarId = car.CarId,
        TenXe = car.TenXe,
        SoGhe = car.SoGhe,
        Loai = car.Loai,
        NhienLieu = car.NhienLieu,
        DiaDiem = car.DiaDiem,
        MoTa = car.MoTa,
        GiaThueNgay = car.GiaThueNgay,
        GiaThueGio = car.GiaThueGio,
        Avatar = car.Avatar,
        

    };

    return View(model); 
        
    }
   [HttpPost]
public IActionResult Create(ThueXeViewModel model, int soGioThue)
{
    var car = _quanLyXeThueContext.XeThues.FirstOrDefault(x => x.CarId == model.CarId);

    if (car == null)
    {
       
        ModelState.AddModelError("", "Không tìm thấy xe.");
        return View("ThueXe", model);
    }

    if (ModelState.IsValid)
    {
        var hopDong = new HopDong
        {
            UserId = HttpContext.Session.GetString("UserID"),
            CarId = car.CarId,
            RentalId = GenerateRandomString(8),
            PhuongThucThue = model.PhuongThucThue,
            NgayThue = model.NgayThue,
            NgayKetThuc = model.NgayKetThuc ?? model.NgayThue,
            TongChiPhi = 0,  
            TrangThai = "Chờ xác nhận",
            SttGiaoXe = null,
            SttNhanXe = null,
        };

        
        if (hopDong.PhuongThucThue == "Thuê ngày" && hopDong.NgayThue.HasValue && hopDong.NgayKetThuc.HasValue)
        {
            var duration = (hopDong.NgayKetThuc.Value - hopDong.NgayThue.Value).Days;
            hopDong.TongChiPhi = duration * car.GiaThueNgay; 
        }
        else if (hopDong.PhuongThucThue == "Thuê 4 giờ" && hopDong.NgayThue.HasValue)
        {
            DateTime currentTime = DateTime.Now;
            DateTime calculatedEndTime = currentTime.AddHours(soGioThue * 4);

            if (calculatedEndTime.Hour >= 23 || calculatedEndTime.Hour < 8)
            {
                model.CarId = car.CarId;
                model.TenXe = car.TenXe;
                model.SoGhe = car.SoGhe;
                model.Loai = car.Loai;
                model.NhienLieu = car.NhienLieu;
                model.DiaDiem = car.DiaDiem;
                model.MoTa = car.MoTa;
                model.GiaThueNgay = car.GiaThueNgay;
                model.GiaThueGio = car.GiaThueGio;
                model.Avatar = car.Avatar;

                ModelState.AddModelError("InvalidRentalTime", "Không được thuê từ 23:00 đến 08:00.");
                return View("ThueXe", model);
            }

            hopDong.NgayKetThuc = calculatedEndTime;
            hopDong.TongChiPhi = soGioThue * car.GiaThueGio;  
        }

      
        _quanLyXeThueContext.HopDongs.Add(hopDong);
        _quanLyXeThueContext.SaveChanges();

        return RedirectToAction("Index");
    }

   
    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
    {
        ModelState.AddModelError(string.Empty, error.ErrorMessage);
    }

   
    if (car != null)
    {
        model.CarId = car.CarId;
        model.TenXe = car.TenXe;
        model.SoGhe = car.SoGhe;
        model.Loai = car.Loai;
        model.NhienLieu = car.NhienLieu;
        model.DiaDiem = car.DiaDiem;
        model.MoTa = car.MoTa;
        model.GiaThueNgay = car.GiaThueNgay;
        model.GiaThueGio = car.GiaThueGio;
        model.Avatar = car.Avatar;
    }

    return View("ThueXe", model);
}

    public IActionResult Lookup()
    {
        return View();
    }
    public IActionResult Partners ()
    {
         return View();
    }
    [Route("Home/ProductDetail/{id}")]
   public IActionResult ProductDetail (string id)
    {var xeThue = _quanLyXeThueContext.XeThues.Include(x=>x.Feats).Include(x=>x.XeImgs).FirstOrDefault(x => x.CarId == id);

         return View(xeThue);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
     private string GenerateRandomString(int length)
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    var random = new Random();
    return new string(Enumerable.Repeat(chars, length)
                                .Select(s => s[random.Next(s.Length)]).ToArray());
}

}

