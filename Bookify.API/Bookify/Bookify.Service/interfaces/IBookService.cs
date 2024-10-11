using Bookify.Service.Beans;
using Domain.Entities;
using System.Security.Claims;

namespace Bookify.Service.interfaces
{
    public interface IBookService
    {
        Task<Book?> AddBook(BookInterface bookInterface, Claim claim);
        Task<Book?> UpdateBook(BookInterface bookInterface);
        Task<Boolean?> DeleteBook(Guid Id);
        Task<IEnumerable<Book?>?> GetAllBooks(Claim claim);
        Task<Book?> GetBookById(Guid BookId);
    }
}
