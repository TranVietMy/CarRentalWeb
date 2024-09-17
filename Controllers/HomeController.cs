using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;

namespace CarRental.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Lookup()
    {
        return View();
    }
    public IActionResult Partners ()
    {
         return View();
    }
   public IActionResult ProductDetail ()
    {
         return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
