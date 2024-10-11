using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Entities;
using Domain.Interfaces.Navigations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Repository.NavigationRepo
{
    public class UserBookShopRepository : GenericRepository<User_Bookshop>, IUserBookShop
    {
        public UserBookShopRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }

        public async Task<IEnumerable<User_Bookshop>> GetBookShopByUserId(Claim claim, UserManager<User> userManager)
        {
            var user = await userManager.FindByEmailAsync(claim.Value);

            var userBookShops = await _bookifyDbContext.User_BookShop.Where<User_Bookshop>(a => a.UserId == user.Id).ToListAsync();

            foreach(var userBookShop in userBookShops)
            {
                userBookShop.BookShop = await _bookifyDbContext.BookShop.FindAsync(userBookShop.BookShopId);
            }

            return userBookShops;
        }
    }
}
