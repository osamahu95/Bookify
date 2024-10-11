using Bookify.Data.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class StockRepository : GenericRepository<Stock>, IStock
    {
        public StockRepository(BookifyDbContext bookifyDbContext) : base(bookifyDbContext)
        {
        }

        public async Task<Stock?> GetByBookId(Guid BookId)
        {
            var bookStock = await _bookifyDbContext.Book_Stock.FirstOrDefaultAsync(bs => bs.BookId == BookId);
            if(bookStock == null)
                return null;

            var stock = await _bookifyDbContext.Stock.FindAsync(bookStock.StockId);
            return stock;
        }
    }
}
