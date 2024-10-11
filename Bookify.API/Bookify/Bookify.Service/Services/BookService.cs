using Bookify.Domain.Navigations;
using Bookify.Service.Beans;
using Bookify.Service.interfaces;
using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Bookify.Service.Services
{
    public class BookService: IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public BookService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Book?> AddBook(BookInterface bookInterface, Claim claim)
        {
            Book book = bookInterface.Book;
            List<Category> categories = bookInterface.Categories;
            Author author = bookInterface.Author;

            var user = await _userManager.FindByEmailAsync(claim.Value);
            book.Id = Guid.NewGuid();

            await _unitOfWork.books.Add(book);

            // Add User Book
            User_Book userBook = new User_Book();
            userBook.Id = Guid.NewGuid();

            userBook.UserId = user.Id;
            userBook.User = user;

            userBook.BookId = book.Id;
            userBook.Book = book;

            await _unitOfWork.userBooks.Add(userBook);

            // Add Book categories
            foreach(var category in categories)
            {
                Book_Category bookCategory = new Book_Category();
                bookCategory.Id = Guid.NewGuid();

                bookCategory.BookId = book.Id;
                bookCategory.CategoryId = category.Id;

                await _unitOfWork.bookCategories.Add(bookCategory);
            }

            Author_Book bookAuthor = new Author_Book();
            bookAuthor.Id = Guid.NewGuid();

            bookAuthor.BookId = book.Id;
            bookAuthor.AuthorId = author.Id;

            await _unitOfWork.authorBooks.Add(bookAuthor);

            await _unitOfWork.complete();

            return book;
        }

        public async Task<bool?> DeleteBook(Guid Id)
        {
            var book = await _unitOfWork.books.GetByid(Id);

            var delete = _unitOfWork.books.Remove(book);

            await _unitOfWork.complete();

            return delete;
        }

        public async Task<IEnumerable<Book?>?> GetAllBooks(Claim claim)
        {
            var user = await _userManager.FindByEmailAsync(claim.Value);
            var books = await _unitOfWork.books.GetAllByUserId(user);

            return books;
        }

        public async Task<Book?> GetBookById(Guid BookId)
        {
            var book = await _unitOfWork.books.GetByid(BookId);
            return book;
        }

        public async Task<Book?> UpdateBook(BookInterface bookInterface)
        {
            Book book = bookInterface.Book;
            List<Category> categories = bookInterface.Categories;
            Author author = bookInterface.Author;

            _unitOfWork.books.Edit(book);

            // Update User Author
            var bookAuthor = await _unitOfWork.authorBooks.Find(ab => ab.BookId == book.Id);
            bookAuthor.AuthorId = author.Id;

            _unitOfWork.authorBooks.Edit(bookAuthor);

            // Update Book Categories
            var bookCategories = await _unitOfWork.bookCategories.FindAll(bc => bc.BookId == book.Id);
            foreach(var bc in bookCategories)
            {
                // Delete book category
                _unitOfWork.bookCategories.Remove(bc);
            }

            // Add to the Book Category
            foreach(var category in categories)
            {
                Book_Category bookCategory = new Book_Category();
                bookCategory.Id = Guid.NewGuid();

                bookCategory.BookId = book.Id;
                bookCategory.CategoryId = category.Id;

                await _unitOfWork.bookCategories.Add(bookCategory);
            }

            await _unitOfWork.complete();

            return book;
        }
    }
}
