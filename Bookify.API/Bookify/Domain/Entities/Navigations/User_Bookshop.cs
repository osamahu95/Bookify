using Domain.Entities;

namespace Bookify.Domain.Navigations
{
    public class User_Bookshop
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid BookShopId { get; set; }
        public BookShop? BookShop { get; set; }
    }
}
