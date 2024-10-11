using Domain.Interfaces;
using Domain.Interfaces.Navigations;

namespace Domain.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        IAuthor authors { get; }
        IBook books { get; }
        IBookShop bookShops { get; }
        ICategory categories { get; }
        IStock stocks { get; }
        IUser users { get; }
        IAuthorBook authorBooks { get; }
        IBookBookShop bookBookShops { get; }
        IBookCategory bookCategories { get; }
        IBookStock bookStocks { get; }
        IUserAuthor userAuthors { get; }
        IUserBook userBooks { get; }
        IUserBookShop userBookShops { get; }

        Task<int> complete();
    }
}
