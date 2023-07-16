using ShopWebMVC.Common;
using ShopWebMVC.Data;
using ShopWebMVC.Models;
using ShopWebMVC.Respon;

namespace ShopWebMVC.Repon
{
    public class AdminReponsitory : ReponsitoryBase<Admin>
    {
        public AdminReponsitory(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public Admin LoginAdmin(AdminLogin requests)
        {
            try
            {
                var checkLogin = FindByCondition(admin => admin.Email.Equals(requests.Email) && admin.Password.Equals(Untill.CreateMD5(requests.Password))).FirstOrDefault();
                if (checkLogin == null)
                {
                    return null;
                }
                return checkLogin;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
