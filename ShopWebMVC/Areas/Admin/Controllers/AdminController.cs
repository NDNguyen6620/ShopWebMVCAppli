using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShopWebMVC.Common;
using ShopWebMVC.Data;
using ShopWebMVC.Models;
using ShopWebMVC.Repon;
using System.Data;
using System.Security.Claims;

namespace ShopWebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly AdminReponsitory _adminRespository;

        public AdminController(AppDbContext appDbContext)
        {
            _context = appDbContext;
            _adminRespository = new AdminReponsitory(appDbContext);
        }
        public IActionResult Index()
        {
            return View();
        }
        //Login
        [Route("Login", Name = "Login")]

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [Route("Login", Name = "Login")]
        public IActionResult Login(AdminLogin requests)
        {
            if (ModelState.IsValid)
            {
                var login = _adminRespository.LoginAdmin(requests);
                if (login != null)
                {
                    var identity = new ClaimsIdentity(new[]
                   {
                        new Claim (ClaimTypes.Name , Convert.ToString(login.Name)),
                        new Claim (ClaimTypes.Email , Convert.ToString(login.Email)),
                        new Claim (ClaimTypes.NameIdentifier, Convert.ToString(login.Id)),
                        new Claim (ClaimTypes.Role,login.typeAdmin.ToString()),
                    }, "Admins");

                    var pricipal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync("Admins", pricipal);
                    return RedirectToAction("Index", "Admin");

                }
                else
                {
                    ModelState.AddModelError("Email", "User account or password incorrect");
                }

            }
            return View(requests);
        }

        //Logout
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Admin");
        }

    }
}
