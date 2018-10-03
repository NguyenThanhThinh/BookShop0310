namespace BookShop0310.Data.Models
{
    public class CategoryBook
    {
        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public Book Book { get; set; }

        public int BookId { get; set; }
    }
}
