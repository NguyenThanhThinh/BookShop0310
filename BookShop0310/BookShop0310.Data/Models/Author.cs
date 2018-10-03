using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop0310.Data.Models
{
    using static DataConstants;

    public class Author : Entity<int>
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }

        public IList<Book> Books { get; set; } = new List<Book>();
    }
}