namespace Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        // navigation properties
        /*public List<Book_Category>? Book_Categories { get; set; }*/
    }
}
