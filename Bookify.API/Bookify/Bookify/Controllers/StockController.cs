using Bookify.Service.Beans;
using Bookify.Service.interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [Route("{BookId:Guid}")]
        public async Task<IActionResult> GetStockByBook(Guid BookId)
        {
            var stock = await _stockService.GetStockByBook(BookId);
            return Ok(stock);
        }

        [HttpPost]
        public async Task<IActionResult> AddStock([FromBody] StockBookInterface stockBookInterface)
        {
            var stock = await _stockService.AddStock(stockBookInterface);
            return Ok(stock);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(Stock stock)
        {
            var s = await _stockService.UpdateStock(stock);
            return Ok(s);
        }
    }
}
