using CarRental.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QuanLyXeThueContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection")));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Th?i gian h?t h?n phiên
    options.Cookie.HttpOnly = true; // Ch? cho phép truy c?p cookie qua HTTP
    options.Cookie.IsEssential = true; // Cookie c?n thi?t cho ?ng d?ng
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Login",
    pattern: "/login",
    defaults: new { controller = "Account", action = "Login" }
);
app.MapControllerRoute(
    name: "Register",
    pattern: "/register",
    defaults: new { controller = "Account", action = "Register" }
);
app.MapControllerRoute(
    name: "ForgotPassword",
    pattern: "/forgotpassword",
    defaults: new { controller = "Account", action = "ForgotPassword" }
);
app.MapControllerRoute(
    name: "Lookup",
    pattern: "/lookup",
    defaults: new { controller = "Home", action = "Lookup" }
);
app.MapControllerRoute(
    name: "Partners",
    pattern: "/partners",
    defaults: new { controller = "Home", action = "Partners" }
);
app.MapControllerRoute(
    name: "ProductDetail",
    pattern: "/productdetail",
    defaults: new { controller = "Home", action = "ProductDetail" }
);
app.MapControllerRoute(
    name: "ThueXe",
    pattern: "/thuexe",
    defaults: new { controller = "Home", action = "ThueXe" }
);
app.MapControllerRoute(
    name: " HopDong",
    pattern: "/hopdong",
    defaults: new { controller = "Admin", action = "HopDong" }
);
app.Run();
