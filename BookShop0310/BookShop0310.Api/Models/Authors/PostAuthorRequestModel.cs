using System.ComponentModel.DataAnnotations;
using BookShop0310.Data;

namespace BookShop0310.Api.Models.Authors
{
    using static DataConstants;

    public class PostAuthorRequestModel
    {
        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string LastName { get; set; }
    }
}