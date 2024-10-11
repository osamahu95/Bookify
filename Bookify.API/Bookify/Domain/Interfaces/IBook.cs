using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Domain.Interfaces
{
    public interface IBook: IGeneric<Book>
    {
        Task<IEnumerable<Book?>?> GetAllByUserId(User user);
        Task<IEnumerable<Book?>?> GetAllByBookShopId(Guid bookShopId);
    }
}
