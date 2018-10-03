using System.ComponentModel.DataAnnotations;
using BookShop0310.Data;

namespace BookShop0310.Api.Models.Categories
{
    using static DataConstants;

    public class CreateCategoryRequestModel
    {
        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }
    }
}