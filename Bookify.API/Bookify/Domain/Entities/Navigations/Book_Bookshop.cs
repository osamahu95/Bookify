using Domain.Entities;

namespace Bookify.Domain.Navigations
{
    public class Book_Bookshop
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public Guid BookshopId { get; set; }
        public BookShop? BookShop { get; set; }
    }
}
