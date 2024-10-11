using Bookify.Data.Data;
using Bookify.Domain.Navigations;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategory
    {
        public CategoryRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }

        public async Task<IEnumerable<Category?>?> SelectCategoriesByBookId(Guid BookId)
        {
            var categories = new List<Category>();

            var bookCategories = await _bookifyDbContext.Book_Category.Where<Book_Category>(bc => bc.BookId == BookId).ToListAsync();
            foreach (var bookCategory in bookCategories)
            {
                var category = await _bookifyDbContext.Category.FindAsync(bookCategory.CategoryId);
                categories.Add(category);
            }

            return categories;
        }
    }
}
