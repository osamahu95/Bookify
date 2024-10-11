using Domain.Entities;
using System.Security.Claims;

namespace Bookify.Service.interfaces
{
    public interface IAuthorService
    {
        Task<Author?> GetSingleAuthor(Guid Id);
        Task<IEnumerable<Author?>?> GetAllUserAuthors(Claim claim);
        Task<Author?> GetBookAuthors(Guid BookId);
        Task<Author?> AddAuthor(Author author, Claim claim);
        Task<Author?> UpdateAuthor(Author author);
        Task<Author?> DeleteAuthor(Guid AuthorId);
    }
}
