using Bookify.Service.Beans;
using Domain.Entities;

namespace Bookify.Service.interfaces
{
    public interface IStockService
    {
        Task<Stock?> GetStockByBook(Guid Bookid);
        Task<Stock?> AddStock(StockBookInterface stockBookInterface);
        Task<Stock?> UpdateStock(Stock stock);
    }
}
