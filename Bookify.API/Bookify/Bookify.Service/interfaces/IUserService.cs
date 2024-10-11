using Bookify.Service.Beans;
using Microsoft.AspNetCore.Identity;

namespace Bookify.Service.interfaces
{
    public interface IUserService
    {
        Task<IdentityResult?> SignUp(UserRegister userRegister);
        Task<string?> SignIn(UserLogin userLogin);
    }
}
