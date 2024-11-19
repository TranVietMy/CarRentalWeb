        using System.Diagnostics;
        using Microsoft.AspNetCore.Mvc;
        using CarRental.Models;
        using System.Text.Json;

        namespace CarRental.Controllers;

        public class ProductController : Controller
        {

            private readonly QuanLyXeThueContext _quanLyXeThueContext;
            private readonly ILogger<ProductController> _logger;
            public ProductController(QuanLyXeThueContext quanLyXeThueContext,ILogger<ProductController> logger)
            {
                _quanLyXeThueContext = quanLyXeThueContext;
                _logger=logger;
            }


            public IActionResult Index()
            { var xeThues=_quanLyXeThueContext.XeThues.ToList();
            TempData["XeThuesData"] = JsonSerializer.Serialize(xeThues);
            TempData.Keep("XeThuesData");
                return RedirectToAction("Index","Home");
                
            }

            // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            // public IActionResult Error()
            // {
            //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            // }
        }
