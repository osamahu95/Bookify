using Domain.Entities;

namespace Bookify.Domain.Navigations
{
    public class User_Author
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }
        public User? User { get; set; }

        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}
