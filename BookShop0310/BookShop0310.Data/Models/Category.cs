using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop0310.Data.Models
{
    using static DataConstants;
    public class Category : Entity<int>
    {
        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        public List<CategoryBook> Books { get; set; } = new List<CategoryBook>();
    }
}