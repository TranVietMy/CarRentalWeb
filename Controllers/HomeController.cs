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
}
