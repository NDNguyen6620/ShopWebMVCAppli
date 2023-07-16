using System.Linq.Expressions;

namespace ShopWebMVC.Respon
{
    public interface IRepositoryBase<T>
    {
        //Find all object
        IEnumerable<T> FindAll();
        //Find by id object
        T FindById(object id);
        IEnumerable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
