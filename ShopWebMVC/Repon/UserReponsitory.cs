

using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ShopWebMVC.Common;
using ShopWebMVC.Data;
using ShopWebMVC.Models;
using System.Drawing;

namespace ShopWebMVC.Repon
{
    public class UserReponsitory : ReponsitoryBase<User>
    {
        private readonly AppDbContext _appDbContext;
        public UserReponsitory(AppDbContext appDbContext) : base(appDbContext) {
            _appDbContext = appDbContext;
        }
        // public List<User> GetQuery()
        //Login
        public User Login(UserLogin requests)
        {
            try
            {
                var checkLogin = FindByCondition(u => u.Email.Equals(requests.Email) && u.Password.Equals(Untill.CreateMD5(requests.Password))).FirstOrDefault();
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
        //Register
        public User Register(User requests)
        {
            try
            {
                var checkRegis = FindByCondition(u => u.Email.Equals(requests.Email)).FirstOrDefault();
                if(checkRegis != null)
                {
                    return null;
                }
                else
                {
                    requests.Password = Untill.CreateMD5(requests.Password);
                    var user = Create(requests);
                    SaveChange();
                    return user;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Edit
        public User EditUser(User user, int id)
        {
            try
            {
                user.Id = id;
                var users = Update(user);
                SaveChange();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Delete
        public bool DeleteUser(User user, int id)
        {
            try
            {
                user.Id = id;
                var users = Delete(user);
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
