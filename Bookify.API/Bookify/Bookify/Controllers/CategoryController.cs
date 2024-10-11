using Bookify.Service.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> AllCategories()
        {
            var categories = await _categoryService.CategoriesList();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetSingleCategory([FromRoute] Guid id)
        {
            var category = await _categoryService.GetSingleCategory(id);
            return Ok(category);
        }

        [HttpGet("AllBookCategories/{id}")]
        public async Task<IActionResult> GetBookCategories(Guid id)
        {
            var categories = await _categoryService.GetCategoriesListByBookId(id);
            return Ok(categories);
        }
    }
}
