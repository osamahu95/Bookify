using Bookify.Domain.Navigations;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Domain.Interfaces.Navigations
{
    public interface IUserBookShop: IGeneric<User_Bookshop>
    {
        Task<IEnumerable<User_Bookshop>> GetBookShopByUserId(Claim claim, UserManager<User> userManager);
    }
}
