using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }

        [Required]
        public int ItemStock { get; set; }

        // navigation properties
        /*public Book_Stock? Book_Stock { get; set; }*/
    }
}
