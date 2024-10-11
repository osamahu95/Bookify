using Bookify.Data.Data;
using Domain.Interfaces;
using Domain.Interfaces.Navigations;
using Repository.NavigationRepo;
using Repository.Repositories;

namespace Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookifyDbContext _bookifyDbContext;

        public UnitOfWork(BookifyDbContext bookifyDbContext)
        {
            _bookifyDbContext=bookifyDbContext;

            authors = new AuthorRepository(_bookifyDbContext);
            books = new BookRepository(_bookifyDbContext);
            bookShops = new BookShopRepository(_bookifyDbContext);
            categories = new CategoryRepository(_bookifyDbContext);
            stocks = new StockRepository(_bookifyDbContext);
            users = new UserRepository(_bookifyDbContext);
            authorBooks = new AuthorBookRepository(_bookifyDbContext);
            bookBookShops = new BookBookShopRepository(_bookifyDbContext);
            bookCategories = new BookCategoryRepository(_bookifyDbContext);
            bookStocks = new BookStockRepository(_bookifyDbContext);
            userAuthors = new UserAuthorRepository(_bookifyDbContext);
            userBooks = new UserBookRepository(_bookifyDbContext);
            userBookShops = new UserBookShopRepository(_bookifyDbContext);
        }

        public IAuthor authors { get; private set; }

        public IBook books { get; private set; }

        public IBookShop bookShops { get; private set; }

        public ICategory categories { get; private set; }

        public IStock stocks { get; private set; }

        public IUser users { get; private set; }

        public IAuthorBook authorBooks { get; private set; }

        public IBookBookShop bookBookShops { get; private set; }

        public IBookCategory bookCategories { get; private set; }

        public IBookStock bookStocks { get; private set; }

        public IUserAuthor userAuthors { get; private set; }

        public IUserBook userBooks { get; private set; }

        public IUserBookShop userBookShops { get; private set; }

        public async Task<int> complete()
        {
            return await _bookifyDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _bookifyDbContext.Dispose();
        }
    }
}
