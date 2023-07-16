using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopWebMVC.Data;
using ShopWebMVC.Models;
using ShopWebMVC.Repon;
using System.Data;

namespace ShopWebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly CategoryReponsitory _categoryReponsitory;

        public CategoryController(AppDbContext context)
        {
            _context = context;
            _categoryReponsitory = new CategoryReponsitory(context);
        }

        // GET: Admin/Category
        [Authorize(Roles = ("SuperAdmin"))]
        public async Task<IActionResult> Index()
        {
              return _context.Categories != null ? 
                          View(await _context.Categories.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Categories'  is null.");
        }

        // GET: Admin/Category/Details/5
        [Authorize(Roles = ("SuperAdmin"))]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var category = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // GET: Admin/Category/Create
        [Authorize(Roles = ("SuperAdmin"))]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model, IFormFile files)
        {
            try
            {
                _categoryReponsitory.CreatedCategory(model, files);
                TempData["result"] = "more success";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Admin/Category/Edit/5
        [Authorize(Roles = ("SuperAdmin"))]
        public async Task<IActionResult> Edit(int id)
        {
            var edit = _categoryReponsitory.FindById(id);
            return View(edit);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category model,int id, IFormFile files)
        {
            try
            {
                _categoryReponsitory.EditCategory(model, id, files);
                TempData["result"] = "more success";
                return RedirectToAction("Index");
            }catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }
        // POST: Admin/Category/Delete/5
        [Authorize(Roles = ("SuperAdmin"))]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var color = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (color == null)
            {
                return NotFound();
            }

            return View(color);
        }
        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Category model,int id)
        {
            try
            {
                _categoryReponsitory.DeleteCategory(model, id);
                TempData["result"] = "more success";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        private bool CategoryExists(int id)
        {
          return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
