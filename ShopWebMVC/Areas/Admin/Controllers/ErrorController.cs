using Microsoft.AspNetCore.Mvc;

namespace ShopWebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
