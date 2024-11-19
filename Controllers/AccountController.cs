using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CarRental.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

namespace CarRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly QuanLyXeThueContext _context;

        public AccountController(QuanLyXeThueContext context)
        {
            _context = context;
        }

         // Hiển thị form đăng ký
        public IActionResult Register()
        {
            return View();
        }

        // Xử lý dữ liệu đăng ký
        [HttpPost]
        public async Task<IActionResult> RegisterModel(User model,string ConfirmPassword)
        {
            
                if (model.Password != ConfirmPassword)
            ViewBag.ConfirmPasswordError = "Mật khẩu xác nhận không khớp.";
            
        
                // Kiểm tra phone hoặc tên tài khoản đã tồn tại chưa
                bool phoneExists = await _context.Users.AnyAsync(t => t.Phone == model.Phone);
                bool usernameExists = await _context.Users.AnyAsync(t => t.UserName == model.UserName); 
                if (phoneExists)
                {ViewBag.PhoneError = "Số điện thoại đã được sử dụng.";
                    
                }

                if (usernameExists)
                {ModelState.AddModelError("UserName", "Username đã tồn tại.");
                   // ViewBag.UserNameError = "Username đã tồn tại.";
                }

                 if (!phoneExists && !usernameExists)
                {
                     model.UserId = GenerateRandomString(8);
                     model.Role = "Customer";
                    // Lưu thông tin tài khoản
                    _context.Users.Add(model);
                    await _context.SaveChangesAsync();

                    // Chuyển hướng người dùng đến trang đăng nhập
                    return RedirectToAction("Login", "Account");
                }
            

            return View("Register", model);
        }

        
        
        public IActionResult Login()
        {
            return View();
        }

        // Xử lý dữ liệu đăng nhập
        [HttpPost]
        public async Task<IActionResult> LoginModel(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                // Thiết lập session cho người dùng
                HttpContext.Session.SetString("UserID", user.UserId);
                HttpContext.Session.SetString("Username", user.UserName);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return View();
        }

        private string GenerateRandomString(int length)
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    var random = new Random();
    return new string(Enumerable.Repeat(chars, length)
                                .Select(s => s[random.Next(s.Length)]).ToArray());
}
    }
}

