using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Author
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        public string? Description { get; set; }

        // navigation properties
        /*public List<Author_Book>? Author_Books { get; set; }
        public User_Author? User_Author { get; set; }*/
    }
}
