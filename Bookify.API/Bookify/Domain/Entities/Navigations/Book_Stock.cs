using Domain.Entities;

namespace Bookify.Domain.Navigations
{
    public class Book_Stock
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public Guid StockId { get; set; }
        public Stock? Stock { get; set; }
    }
}
