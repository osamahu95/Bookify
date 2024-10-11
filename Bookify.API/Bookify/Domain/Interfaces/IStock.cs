using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IStock: IGeneric<Stock>
    {
        Task<Stock?> GetByBookId(Guid BookId);
    }
}
