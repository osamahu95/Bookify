using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Interfaces.Navigations;

namespace Repository.NavigationRepo
{
    public class BookCategoryRepository : GenericRepository<Book_Category>, IBookCategory
    {
        public BookCategoryRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }
    }
}
