using Microsoft.EntityFrameworkCore;
using System;
using ShopWebMVC.Data;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews(); 
builder.Services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("AppConnection")
                )
            );
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthentication("Admins").AddCookie("Admins", option =>
{
    option.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = "Admin.Security.Cookie",
        Path = "/",
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.SameAsRequest

    };
    option.SlidingExpiration = true;


    option.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        Name = "User.Security.Cookie",
        Path = "/",
        SameSite = SameSiteMode.Lax,
        SecurePolicy = CookieSecurePolicy.SameAsRequest
    };
    option.LoginPath = new PathString("/Login");
    option.SlidingExpiration = true;
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas_admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();