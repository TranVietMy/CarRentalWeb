using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;

namespace CarRental.Controllers;

public class CartController : Controller
{
    private readonly ILogger<CartController> _logger;

    public CartController(ILogger<CartController> logger)
    {
        _logger = logger;
    }


    public IActionResult Bill()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
