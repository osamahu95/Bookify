using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategory: IGeneric<Category>
    {
        Task<IEnumerable<Category?>?> SelectCategoriesByBookId(Guid BookId);
    }
}
