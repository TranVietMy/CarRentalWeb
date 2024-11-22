using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;

namespace CarRental.Controllers;

public class OwnerController : Controller
{
    private readonly ILogger<OwnerController> _logger;
    private readonly QuanLyXeThueContext _context;

    public OwnerController(ILogger<OwnerController> logger,QuanLyXeThueContext context)
    {
        _logger = logger;
        _context=context;
    }
    public IActionResult AddCar(AddCarModel model){
        model.HangXes = _context.HangXes.ToList();
    model.AllFeats = _context.TinhNangs.ToList();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddCarFunc(AddCarModel model)
    {
            
        if (ModelState.IsValid)
    {
        // Tạo đối tượng XeThue mới
        // Lấy OwnerID từ session
        var ownerId = HttpContext.Session.GetString("OwnerID");
        if (string.IsNullOrEmpty(ownerId))
        {
            TempData["ErrorMessage"] = "Bạn cần đăng nhập để thêm xe.";
            return RedirectToAction("Login", "Account"); 
        }
        var xeThue = new XeThue
        {
            CarId = GenerateRandomString(8),
            TenXe = model.TenXe,
            SoGhe = model.SoGhe,
            Loai = model.Loai,
            NhienLieu = model.NhienLieu,
            TrangThai = "rảnh",  
            DiaDiem = model.DiaDiem,
            MoTa = model.MoTa,
            GiaThueNgay = model.GiaThueNgay,
            GiaThueGio = model.GiaThueGio,
            Avatar = model.Avatar,
            ModelId = model.ModelId,  
            OwnId = ownerId, 
        };
        

        // Thêm các tiện nghi vào xe
        foreach (var featId in model.SelectedFeats)
        {
            var feature = await _context.TinhNangs.FindAsync(featId);
            if (feature != null)
            {
                xeThue.Feats.Add(feature);
            }
        }

        if (model.AdditionalImages != null && model.AdditionalImages.Any())
        {
            foreach (var imgUrl in model.AdditionalImages)
            {
                var xeImg = new XeImg
                {
                    Img = imgUrl, 
                    CarId = xeThue.CarId
                };
                xeThue.XeImgs.Add(xeImg);
            }
        }

        // Lưu xe vào cơ sở dữ liệu
        _context.XeThues.Add(xeThue);
        await _context.SaveChangesAsync();
        TempData["SuccessMessage"] = "Đã thêm thành công!";

        return RedirectToAction("Accept", "Owner");
    }
    if (!ModelState.IsValid)
{
    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
    {TempData["ErrorMessage"]=error.ErrorMessage;
        
    }
}

    // Nếu có lỗi, trả về form thêm xe với lỗi
    model.HangXes = _context.HangXes.ToList();
    model.AllFeats = _context.TinhNangs.ToList();
    return View("AddCar",model);
       
    }

    [HttpGet("GetMauXeByCateId")]
        public IActionResult GetMauXeByCateId(string cateId)
        {
            var mauXes = _context.MauXes.Where(m => m.CateId == cateId)
                                        .Select(m => new 
                                        {
                                            modelId = m.ModelId,
                                            modelName = m.TenMau
                                        })
                                        .ToList();
_logger.LogInformation($"MauXes for CateId {cateId}: {string.Join(", ", mauXes.Select(m => m.modelName))}");
            return Json(mauXes);
        }
    public IActionResult Accept()
    {
        return View();
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
