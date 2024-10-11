using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Interfaces.Navigations;

namespace Repository.NavigationRepo
{
    public class BookBookShopRepository : GenericRepository<Book_Bookshop>, IBookBookShop
    {
        public BookBookShopRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }
    }
}
