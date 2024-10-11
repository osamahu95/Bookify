using Bookify.Service.Beans;
using Domain.Entities;
using System.Security.Claims;

namespace Bookify.Service.interfaces
{
    public interface IBookShopService
    {
        Task<BookShop?> GetSingleBookShop(Guid Id);
        Task<IEnumerable<BookShop?>?> GetUserBookShops(Claim userClaim);
        Task<IEnumerable<Book?>?> GetBooksByBookshopId(Guid BookShopId);
        Task<BookShop?> GetBookShopByBookId(Guid BookId);
        Task<BookShop?> AddBookToBookShop(Book_BookShopInterface bookBookShops);
        Task<BookShop?> UpdateBookToBookShop(Book_BookShopInterface bookBookShops);
        Task<BookShop?> AddBookShop(BookShop bookShop, Claim userClaim);
        Task<BookShop?> UpdateBookShop(BookShop bookShop);
        Task<BookShop?> DeleteBookShop(Guid BookShopId);
    }
}
