using Bookify.Domain.Navigations;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAuthor: IGeneric<Author>
    {
        Task<Author?> GetbyBookId(Guid BookId);
        Task<IEnumerable<User_Author?>?> SelectAuthorsByUserId(User user);
    }
}
