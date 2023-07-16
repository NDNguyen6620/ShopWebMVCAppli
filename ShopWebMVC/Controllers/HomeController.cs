using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWebMVC.Data;
using ShopWebMVC.Models;
using ShopWebMVC.Repon;
using System.Diagnostics;

namespace ShopWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly CategoryReponsitory _categoryReponsitory;
        private readonly ProductReponsitory _productReponsitory;
        private readonly UserReponsitory _userReponsitory;
        public HomeController(AppDbContext appDbContext)
        {
            _categoryReponsitory = new CategoryReponsitory(appDbContext);
            _productReponsitory = new ProductReponsitory(appDbContext);
        }
        [Route("")]
        [Route("Home", Name = "Home")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Shop", Name = "Shop")]
        public IActionResult Shop()
        {
            ViewData["Message"] = "Your Shop page.";

            return View();
        }

        [Route("ProductDetail", Name = "ProductDetail")]
        public IActionResult ProductDetail(int id)
        {
            var setting = _productReponsitory.FindById(id);
             return View(setting);
        }

        [Route("MyOrder", Name = "MyOrder")]
        public IActionResult MyOder()
        {
            return View();
        }

        [Route("Checkout", Name = "Checkout")]
        public IActionResult Checkout()
        {
            return View();
        }

        [Route("Contact", Name = "Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("MyFavorite", Name = "MyFavorite")]
        public IActionResult MyFavorite()
        {
            return View();
        }

        [Route("ShoppingCart", Name = "ShoppingCart")]
        public IActionResult ShoppingCart()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}