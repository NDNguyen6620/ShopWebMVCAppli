using Microsoft.EntityFrameworkCore;
using ShopWebMVC.Models;

namespace ShopWebMVC.Repon
{
    public class ProductReponsitory : ReponsitoryBase<Product>
    {
        public ProductReponsitory(DbContext dbContext) : base(dbContext)
        {
        }
        // public List<Product> GetQuery()
        //Create
        public Product CreatedProduct(Product product, IFormFile files)
        {
            try
            {
                string fileName = files.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\proImg", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    files.CopyTo(stream);
                    product.Image = fileName;
                }
                var categories = Create(product);
                SaveChange();
                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Edit
        public Product EditProduct(Product product, int id, IFormFile files)
        {
            try
            {
                string fileName = files.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\proImg", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    files.CopyTo(stream);
                    product.Image = fileName;
                }
                var categories = Update(product);
                SaveChange();
                return categories;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Delete
        public bool DeleteProduct(Product product, int id)
        {
            try
            {
                product.Id = id;
                if (product.Image != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\ProImg", product.Image);
                    System.IO.File.Delete(path);
                }
                var products = Delete(product);
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
