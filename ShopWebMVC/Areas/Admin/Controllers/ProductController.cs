using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopWebMVC.Data;
using ShopWebMVC.Models;
using ShopWebMVC.Repon;

namespace ShopWebMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ProductReponsitory _productReponsitory;

        public ProductController(AppDbContext context)
        {
            _context = context;
            _productReponsitory = new ProductReponsitory(context);
        }

        // GET: Admin/Product
        [Authorize(Roles = ("SuperAdmin"))]
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Products.Include(p => p.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Product/Details/5
        [Authorize(Roles = ("SuperAdmin"))]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Product/Create
        [Authorize(Roles = ("SuperAdmin"))]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model, IFormFile files)
        {
            try
            {
                _productReponsitory.CreatedProduct(model,files);
                TempData["result"] = "more success";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Admin/Product/Edit/5
        [Authorize(Roles = ("SuperAdmin"))]
        public async Task<IActionResult> Edit(int? id)
        {
            var edit = _productReponsitory.FindById(id);
            return View(edit);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product model,int id, IFormFile files)
        {
            try
            {
                _productReponsitory.EditProduct(model,id,files);
                TempData["result"] = "more success";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        // GET: Admin/Product/Delete/5
        [Authorize(Roles = ("SuperAdmin"))]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Product/Delete/5
        [Authorize(Roles = ("SuperAdmin"))]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Product model,int id)
        {
            try
            {
                _productReponsitory.DeleteProduct(model, id);
                TempData["result"] = "more success";
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error");
            }
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
