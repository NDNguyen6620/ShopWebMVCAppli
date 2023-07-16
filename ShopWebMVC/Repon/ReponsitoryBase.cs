using Microsoft.EntityFrameworkCore;
using ShopWebMVC.Models;
using ShopWebMVC.Respon;
using System.Linq.Expressions;

namespace ShopWebMVC.Repon
{
    public class ReponsitoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DbContext _dbContext;

        public ReponsitoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _dbContext.Remove(entity);
            return entity;
        }

        public IEnumerable<T> FindAll()
        {
            return _dbContext.Set<T>();
        }

        public IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().Where(expression);
        }

        public T FindById(object id)
        {
            var model = _dbContext.Set<T>().Find(id);
            return model;
        }

        public T Update(T entity)
        {
            _dbContext.Update(entity);
            return entity;
        }
        public void SaveChange()
        {
            _dbContext.SaveChanges();
        }
    }
}
