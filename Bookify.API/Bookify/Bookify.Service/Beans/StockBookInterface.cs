using Domain.Entities;

namespace Bookify.Service.Beans
{
    public class StockBookInterface
    {
        public Stock? Stock { get; set; }
        public Guid BookId { get; set; }
    }
}
