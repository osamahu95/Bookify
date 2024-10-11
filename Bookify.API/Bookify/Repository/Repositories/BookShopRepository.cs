using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Repository.Repositories
{
    public class BookShopRepository : GenericRepository<BookShop>, IBookShop
    {
        public BookShopRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }

        public async Task<BookShop?> GetByBookId(Guid BookId)
        {
            var book_BookShop = await _bookifyDbContext.Book_BookShop.FirstOrDefaultAsync(bbs => bbs.BookId == BookId);
            
            if(book_BookShop == null)
                return null;

            var bookShop = await _bookifyDbContext.BookShop.FindAsync(book_BookShop.BookshopId);
            return bookShop;
        }

        public async Task<IEnumerable<Book?>?> SelectAllByBookId(Guid BookShopId)
        {
            var bookBookShops = await _bookifyDbContext.Book_BookShop.Where(bbs => bbs.BookshopId == BookShopId).ToListAsync();

            var books = new List<Book>();
            foreach(var bbs in bookBookShops)
            {
                var book = await _bookifyDbContext.Book.FindAsync(bbs.BookId);
                books.Add(book);
            }

            return books;
        }

        public async Task<IEnumerable<User_Bookshop?>?> SelectBookShopByUserId(User user)
        {
            var userBookShops = _bookifyDbContext.User_BookShop.Where<User_Bookshop>(a => a.UserId == user.Id);
            foreach(var userBookShop in userBookShops)
            {
                userBookShop.BookShop = await _bookifyDbContext.BookShop.FindAsync(userBookShop.BookShopId);
            }

            return userBookShops;
        }
    }
}
