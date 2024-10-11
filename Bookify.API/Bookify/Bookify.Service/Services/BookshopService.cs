using Bookify.Domain.Navigations;
using Bookify.Service.Beans;
using Bookify.Service.interfaces;
using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Bookify.Service.Services
{
    public class BookShopService: IBookShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public BookShopService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<BookShop?> AddBookShop(BookShop bookShop, Claim userClaim)
        {
            var user = await _userManager.FindByEmailAsync(userClaim.Value);

            bookShop.Id = Guid.NewGuid();

            // Add to context
            await _unitOfWork.bookShops.Add(bookShop);

            User_Bookshop userBookShop = new User_Bookshop();
            userBookShop.Id = Guid.NewGuid();

            userBookShop.BookShopId = bookShop.Id;
            userBookShop.BookShop = bookShop;

            userBookShop.UserId = user.Id;
            userBookShop.User = user;

            await _unitOfWork.userBookShops.Add(userBookShop);

            await _unitOfWork.complete();

            return bookShop;
        }

        public async Task<BookShop?> AddBookToBookShop(Book_BookShopInterface bookBookShops)
        {
            Book_Bookshop bookBookShop = new Book_Bookshop();
            
            bookBookShop.Id = Guid.NewGuid();
            bookBookShop.BookId = bookBookShops.BookId;
            bookBookShop.BookshopId = bookBookShops.BookshopId;

            await _unitOfWork.bookBookShops.Add(bookBookShop);

            await _unitOfWork.complete();

            return await _unitOfWork.bookShops.GetByid(bookBookShops.BookshopId);
        }

        public async Task<BookShop?> DeleteBookShop(Guid BookShopId)
        {
            var bookShop = await _unitOfWork.bookShops.GetByid(BookShopId);
            var userBookShop = await _unitOfWork.userBookShops.Find(ub => ub.BookShopId == BookShopId);
            var bookBookShops = await _unitOfWork.bookBookShops.FindAll(bbs => bbs.BookshopId == BookShopId);

            if (bookBookShops.Count() > 0)
                return null;

            _unitOfWork.bookShops.Remove(bookShop);
            _unitOfWork.userBookShops.Remove(userBookShop);

            await _unitOfWork.complete();

            return bookShop;
        }

        public async Task<IEnumerable<Book?>?> GetBooksByBookshopId(Guid BookShopId)
        {
            return await _unitOfWork.bookShops.SelectAllByBookId(BookShopId);
        }

        public async Task<BookShop?> GetBookShopByBookId(Guid BookId)
        {
            return await _unitOfWork.bookShops.GetByBookId(BookId);
        }

        public async Task<BookShop?> GetSingleBookShop(Guid Id)
        {
            var bookShop = await _unitOfWork.bookShops.GetByid(Id);
            return bookShop;
        }

        public async Task<IEnumerable<BookShop?>?> GetUserBookShops(Claim userClaim)
        {
            var bookShops = new List<BookShop>();

            var user = await _userManager.FindByEmailAsync(userClaim.Value);
            var userBookShops = await _unitOfWork.bookShops.SelectBookShopByUserId(user);

            foreach(var userBookShop in userBookShops)
            {
                bookShops.Add(userBookShop.BookShop);
            }

            return bookShops;
        }

        public async Task<BookShop?> UpdateBookShop(BookShop bookShop)
        {
            var bs = _unitOfWork.bookShops.Edit(bookShop);
            await _unitOfWork.complete();
            return bs;
        }

        public async Task<BookShop?> UpdateBookToBookShop(Book_BookShopInterface bookBookShop)
        {
            var bbs = await _unitOfWork.bookBookShops.Find(bbs => bbs.BookId == bookBookShop.BookId);
            bbs.BookshopId = bookBookShop.BookshopId;

            _unitOfWork.bookBookShops.Edit(bbs);
            await _unitOfWork.complete();

            return await _unitOfWork.bookShops.GetByid(bookBookShop.BookshopId);
        }


    }
}
