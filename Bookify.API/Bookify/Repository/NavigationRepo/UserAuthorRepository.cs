using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Entities;
using Domain.Interfaces.Navigations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Repository.NavigationRepo
{
    public class UserAuthorRepository : GenericRepository<User_Author>, IUserAuthor
    {
        public UserAuthorRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }

        public async Task<IEnumerable<User_Author?>?> GetByUserId(Claim userClaim, UserManager<User> userManager)
        {
            var user = await userManager.FindByEmailAsync(userClaim.Value);

            // Get User Authors 
            var userAuthors = await _bookifyDbContext.User_Author.Where<User_Author>(a => a.UserId == user.Id).ToListAsync();

            foreach(var author in userAuthors)
            {
                author.Author = await _bookifyDbContext.Author.FindAsync(author.AuthorId);
            }

            return userAuthors;
        }
    }
}
