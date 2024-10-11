using Bookify.Domain.Navigations;
using Bookify.Service.Beans;
using Bookify.Service.interfaces;
using Domain.Entities;
using Domain.UnitOfWork;

namespace Bookify.Service.Services
{
    public class StockService: IStockService
    {
        private IUnitOfWork _unitOfWork;
        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Stock?> AddStock(StockBookInterface stockBookInterface)
        {
            Stock stock = stockBookInterface.Stock;
            Guid bookId = stockBookInterface.BookId;

            // set the new guid for the stock
            stock.Id = Guid.NewGuid();

            // add stock to context 
            await _unitOfWork.stocks.Add(stock);

            // add reference of stock and bookid to bookstock context
            Book_Stock bookStock = new Book_Stock();
            bookStock.Id = Guid.NewGuid();

            bookStock.StockId = stock.Id;
            bookStock.BookId = bookId;

            await _unitOfWork.bookStocks.Add(bookStock);

            //complete
            await _unitOfWork.complete();

            return stock;

        }

        public async Task<Stock?> GetStockByBook(Guid Bookid)
        {
            var stock = await _unitOfWork.stocks.GetByBookId(Bookid);
            return stock;
        }

        public async Task<Stock?> UpdateStock(Stock stock)
        {
            var s = _unitOfWork.stocks.Edit(stock);

            // complete
            await _unitOfWork.complete();

            return s;
        }
    }
}
