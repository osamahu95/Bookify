using Bookify.Data.Data;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        protected readonly BookifyDbContext? _bookifyDbContext;

        public GenericRepository(BookifyDbContext bookifyDbContext)
        {
            _bookifyDbContext = bookifyDbContext;
        }

        public async Task<T?> Add(T entity)
        {
            try
            {
                await _bookifyDbContext.Set<T>().AddAsync(entity);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return entity;
        }

        public T? Edit(T entity)
        {
            try
            {
                _bookifyDbContext.Set<T>().Update(entity);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return entity;
        }

        public async Task<T?> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _bookifyDbContext.Set<T>().FirstOrDefaultAsync(expression);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<T?>> FindAll(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _bookifyDbContext.Set<T>().Where<T>(expression).ToListAsync();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<IEnumerable<T?>> GetAll()
        {
            try
            {
                return await _bookifyDbContext.Set<T>().ToListAsync();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<T?> GetByid(Guid id)
        {
            try
            {
                return await _bookifyDbContext.Set<T>().FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool Remove(T entity)
        {
            try
            {
                _bookifyDbContext.Set<T>().Remove(entity);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}
