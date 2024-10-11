using Bookify.Domain.Navigations;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Domain.Interfaces.Navigations
{
    public interface IUserAuthor: IGeneric<User_Author>
    {
        Task<IEnumerable<User_Author?>?> GetByUserId(Claim userClaim, UserManager<User> userManager);
    }
}
