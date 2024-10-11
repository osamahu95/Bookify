using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Repository.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBook
    {
        public BookRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }

        public async Task<IEnumerable<Book?>?> GetAllByBookShopId(Guid bookShopId)
        {
            var bookBookShops = await _bookifyDbContext.Book_BookShop.Where(bbs => bbs.BookshopId == bookShopId).ToListAsync();

            List<Book?> books = new List<Book?>();
            foreach(var bbs in bookBookShops)
            {
                var book = await _bookifyDbContext.Book.FindAsync(bbs.BookId);
                books.Add(book);
            }

            return books;
        }

        public async Task<IEnumerable<Book?>?> GetAllByUserId(User user)
        {
            var userBooks = await _bookifyDbContext.User_Book.Where<User_Book>(ub => ub.UserId == user.Id).ToListAsync();

            var books = new List<Book>();
            foreach(var userBook in userBooks)
            {
                var book = await _bookifyDbContext.Book.FindAsync(userBook.BookId);
                books.Add(book);
            }

            return books;
        }
    }
}
