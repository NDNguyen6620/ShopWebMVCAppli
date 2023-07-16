using Microsoft.EntityFrameworkCore;
using ShopWebMVC.Common;
using ShopWebMVC.Models;

namespace ShopWebMVC.seeder
{
    public class AdminSeeder
    {
        private readonly ModelBuilder _modelBuilder;
        public AdminSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }

        /// <summary>
        /// Excute data
        /// </summary>
        public void SeedData()
        {
            _modelBuilder.Entity<Admin>().HasData(
               new Admin
               {
                   Id = 1,
                   Name = "Admin",
                   Email = "Admin@gmail.com",
                   Password = Untill.CreateMD5("jwcvd3082001"),
                   typeAdmin = TypeAdmin.SuperAdmin,
               });
        }
    }
}
