using Bookify.Domain.Navigations;
using Domain.Entities;
using System.Security.Claims;

namespace Domain.Interfaces
{
    public interface IBookShop: IGeneric<BookShop>
    {
        Task<BookShop?> GetByBookId(Guid BookId);
        Task<IEnumerable<User_Bookshop?>?> SelectBookShopByUserId(User user);
        Task<IEnumerable<Book?>?> SelectAllByBookId(Guid BookShopId);
    }
}
