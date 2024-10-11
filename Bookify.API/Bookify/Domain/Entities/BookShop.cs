using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BookShop
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Address { get; set; }

        // navigation properties
        /*public List<Book_Bookshop>? Book_Bookshops { get; set; }
        public User_Bookshop? User_Bookshop { get; set; }*/
    }
}
