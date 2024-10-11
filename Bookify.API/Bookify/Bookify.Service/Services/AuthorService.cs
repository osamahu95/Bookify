using Bookify.Domain.Navigations;
using Bookify.Service.interfaces;
using Domain.Entities;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Bookify.Service.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public AuthorService()
        {
        }

        public AuthorService(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Author?> AddAuthor(Author author, Claim claim)
        {
            var user = await _userManager.FindByEmailAsync(claim.Value);

            author.Id = Guid.NewGuid();
            await _unitOfWork.authors.Add(author);

            // User Author Reference
            User_Author userAuthor = new User_Author();
            userAuthor.Id = Guid.NewGuid();

            userAuthor.AuthorId = author.Id;
            userAuthor.Author = author;

            userAuthor.UserId = user.Id;
            userAuthor.User = user;

            await _unitOfWork.userAuthors.Add(userAuthor);

            await _unitOfWork.complete();

            return author;
        }

        public async Task<Author?> DeleteAuthor(Guid AuthorId)
        {
            var author = await _unitOfWork.authors.GetByid(AuthorId);
            var userAuthor = await _unitOfWork.userAuthors.Find(ua => ua.AuthorId == AuthorId);
            var authorBooks = await _unitOfWork.authorBooks.FindAll(ab => ab.AuthorId == AuthorId);

            if (authorBooks.Count() > 0)
                return null;

            _unitOfWork.authors.Remove(author);
            _unitOfWork.userAuthors.Remove(userAuthor);

            await _unitOfWork.complete();

            return author;
        }

        public async Task<IEnumerable<Author?>?> GetAllUserAuthors(Claim claim)
        {
            var authors = new List<Author>();

            var user = await _userManager.FindByEmailAsync(claim.Value);
            var userAuthors = await _unitOfWork.authors.SelectAuthorsByUserId(user);

            foreach(var author in userAuthors)
            {
                authors.Add(author.Author);
            }

            return authors;
        }

        public async Task<Author?> GetBookAuthors(Guid BookId)
        {
            var author = await _unitOfWork.authors.GetbyBookId(BookId);
            return author;
        }

        public async Task<Author?> GetSingleAuthor(Guid Id)
        {
            var author = await _unitOfWork.authors.GetByid(Id);
            return author;
        }

        public async Task<Author?> UpdateAuthor(Author author)
        {
            var a = _unitOfWork.authors.Edit(author);
            await _unitOfWork.complete();

            return a;
        }
    }
}
