using Bookify.Service.interfaces;
using Domain.Entities;
using Domain.UnitOfWork;

namespace Bookify.Service.Services
{
    public class CategoryService: ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Category?>?> CategoriesList()
        {
            return await _unitOfWork.categories.GetAll();
        }

        public async Task<IEnumerable<Category?>?> GetCategoriesListByBookId(Guid BookId)
        {
            return await _unitOfWork.categories.SelectCategoriesByBookId(BookId);
        }

        public async Task<Category?> GetSingleCategory(Guid id)
        {
            return await _unitOfWork.categories.GetByid(id);
        }
    }
}
