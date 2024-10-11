using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Interfaces.Navigations;

namespace Repository.NavigationRepo
{
    public class BookStockRepository : GenericRepository<Book_Stock>, IBookStock
    {
        public BookStockRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }
    }
}
