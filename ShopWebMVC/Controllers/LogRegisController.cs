using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopWebMVC.Data;
using ShopWebMVC.Models;
using ShopWebMVC.Repon;
using System.Security.Claims;

namespace ShopWebMVC.Controllers
{
    public class LogRegisController : Controller
    {
        private readonly UserReponsitory _userReponsitory;
        public LogRegisController(AppDbContext dbContext)
        {
            _userReponsitory = new UserReponsitory(dbContext);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                var login = _userReponsitory.Login(model);
                if (login != null)
                {
                    var identity = new ClaimsIdentity(new[]
                   {
                        new Claim (ClaimTypes.Name , Convert.ToString(login.Name)),
                        new Claim (ClaimTypes.Email , Convert.ToString(login.Email)),
                        new Claim (ClaimTypes.NameIdentifier, Convert.ToString(login.Id))
                    }, "Admins");

                    var pricipal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync("Admins", pricipal);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("Email", "User account or password incorrect");
                }

            }
            return View(model);
        }
        [Route("Register", Name = "Register")]
        public IActionResult Register()
        {
            return View();
        }
        [Route("Register", Name = "Register")]
        [HttpPost]
        public IActionResult Register(User model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var register = _userReponsitory.Register(model);
                    if (register != null)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.error = "Email already exists";
                    }

                }
                return View(model);

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}

