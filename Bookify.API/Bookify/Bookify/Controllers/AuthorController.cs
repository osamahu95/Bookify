using Bookify.Service.Beans.Response;
using Bookify.Service.interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> SingleAuthor([FromRoute] Guid id)
        {
            var author = await _authorService.GetSingleAuthor(id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpGet("AllUserAuthor")]
        public async Task<IActionResult> AllUserAuthors()
        {
            var user = User.Claims.FirstOrDefault();

            var authors = await _authorService.GetAllUserAuthors(user);

            if (authors == null)
                return NotFound();

            return Ok(authors);
        }

        [HttpGet("AuthorBook/{id}")]
        public async Task<IActionResult> GetAuthorByBookId(Guid Id)
        {
            var author = await _authorService.GetBookAuthors(Id);

            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            if (author == null || !ModelState.IsValid)
                return BadRequest();

            var user = User.Claims.FirstOrDefault();
            var result = await _authorService.AddAuthor(author, user);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor([FromBody] Author author)
        {
            if (author == null || !ModelState.IsValid)
                return BadRequest();

            var result = await _authorService.UpdateAuthor(author);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var result = await _authorService.DeleteAuthor(Id);

            if (result != null)
                return Ok();

            return BadRequest(new GeneralResponse { Status = false, Errors =  new List<string> { "Author is Related to Some Books. Please Check before Deletion" } });
        }

    }
}
