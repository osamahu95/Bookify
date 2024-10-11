using Domain.Entities;

namespace Bookify.Service.interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category?>?> CategoriesList();
        Task<Category?> GetSingleCategory(Guid id);
        Task<IEnumerable<Category?>?> GetCategoriesListByBookId(Guid BookId);
    }
}
