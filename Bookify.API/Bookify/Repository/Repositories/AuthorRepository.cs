using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthor
    {
        public AuthorRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }

        public async Task<Author?> GetbyBookId(Guid BookId)
        {
            var authorBook = await _bookifyDbContext.Author_Book.FirstOrDefaultAsync(ba => ba.BookId == BookId);
            var author = await _bookifyDbContext.Author.FindAsync(authorBook.AuthorId);

            return author;
        }

        public async Task<IEnumerable<User_Author?>?> SelectAuthorsByUserId(User user)
        {
            var userAuthors = await _bookifyDbContext.User_Author.Where(a => a.UserId == user.Id).ToListAsync();

            foreach(var author in userAuthors)
            {
                author.Author = await _bookifyDbContext.Author.FindAsync(author.AuthorId);
            }

            return userAuthors;
        }
    }
}
