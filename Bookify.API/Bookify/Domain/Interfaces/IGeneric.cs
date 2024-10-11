using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<T?> GetByid(Guid id);
        Task<IEnumerable<T?>> GetAll();
        Task<T?> Find(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T?>> FindAll(Expression<Func<T, bool>> expression);
        Task<T?> Add(T entity);
        T? Edit(T entity);
        Boolean Remove(T entity);
    }
}
