using Bookify.Service.Beans;
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
    public class BookshopController : Controller
    {
        private IBookShopService _bookShopService;

        public BookshopController(IBookShopService bookShopService)
        {
            _bookShopService = bookShopService;
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> SingleBookShop([FromRoute] Guid id)
        {
            var bookShop = await _bookShopService.GetSingleBookShop(id);
            return Ok(bookShop);
        }

        [HttpGet("AllUserBookshop")]
        public async Task<IActionResult> AllUserBookShops()
        {
            var claim = User.Claims.FirstOrDefault();

            var bookShops = await _bookShopService.GetUserBookShops(claim);
            return Ok(bookShops);
        }

        [HttpPut("AddBookToBookShop")]
        public async Task<IActionResult> AddBookToBookShop([FromBody] Book_BookShopInterface bookBookShopInterface)
        {
            var bookShop = await _bookShopService.AddBookToBookShop(bookBookShopInterface);
            return Ok(bookShop);
        }

        [HttpPut("UpdateBookToBookShop")]
        public async Task<IActionResult> UpdateBookToBookShop([FromBody] Book_BookShopInterface bookBookShopInterface)
        {
            var bookShop = await _bookShopService.UpdateBookToBookShop(bookBookShopInterface);
            return Ok(bookShop);
        }

        [HttpGet("GetBooksByBookshop/{bookShopId}")]
        public async Task<IActionResult> GetBooksByBookShop(Guid BookShopId)
        {
            var books = await _bookShopService.GetBooksByBookshopId(BookShopId);
            return Ok(books);
        }

        [HttpGet("GetBookShopbyBook/{bookId}")]
        public async Task<IActionResult> GetBookShopByBook(Guid BookId)
        {
            var bookShop = await _bookShopService.GetBookShopByBookId(BookId);
            return Ok(bookShop);
        }

        [HttpPost]
        public async Task<IActionResult> AddBookShop([FromBody] BookShop bookShop)
        {
            var userClaim = User.Claims.FirstOrDefault();

            var bs = await _bookShopService.AddBookShop(bookShop, userClaim);
            return Ok(bs);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBookShop([FromBody] BookShop bookShop)
        {
            var bs = await _bookShopService.UpdateBookShop(bookShop);
            return Ok(bs);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var bookShop = await _bookShopService.DeleteBookShop(Id);
            
            if(bookShop != null)
                return Ok();

            return BadRequest(new GeneralResponse { Status = false, Errors =  new List<string> { "BookShop is Related to Some Books. Please Check before Deletion" } });
        }
    }
}
