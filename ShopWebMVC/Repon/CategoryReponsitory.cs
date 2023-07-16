using Microsoft.EntityFrameworkCore;
using ShopWebMVC.Models;
using System.Reflection;

namespace ShopWebMVC.Repon
{
    public class CategoryReponsitory : ReponsitoryBase<Category>
    {
        public CategoryReponsitory(DbContext dbContext) : base(dbContext)
        {
        }
        //Create
        public Category CreatedCategory(Category category, IFormFile files)
        {
            try
            {
                string fileName = files.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\cateImg", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    files.CopyTo(stream);
                    category.Image = fileName;
                }
                var categories = Create(category);
                SaveChange();
                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Edit
        public Category EditCategory(Category category, int id, IFormFile files)
        {
            try
            {
                string fileName = files.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\cateImg", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    files.CopyTo(stream);
                    category.Image = fileName;
                }
                var categories = Update(category);
                SaveChange();
                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Delete
        public bool DeleteCategory(Category category, int id)
        {
            try
            {
                category.Id = id;
                if (category.Image != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\cateImg", category.Image);
                    System.IO.File.Delete(path);
                }
                var categories = Delete(category);
                SaveChange();
                return true;

            }
            catch (Exception ex)
            {
               throw ex;
            };
        }
    }
}
