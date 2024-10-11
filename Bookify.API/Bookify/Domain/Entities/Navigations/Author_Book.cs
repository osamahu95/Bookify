using Domain.Entities;

namespace Bookify.Domain.Navigations
{
    public class Author_Book
    {
        public Guid Id { get; set; }

        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }

        public Guid BookId { get; set; }
        public Book? Book { get; set; }
    }
}
