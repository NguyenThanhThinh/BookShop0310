using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShop0310.Data.Models
{
    using static DataConstants;

    public class Book : Entity<int>
    {
        [Required]
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(PriceMinLength, PriceMaxLength)]
        public double Price { get; set; }

        [Required]
        [Range(CopiesMinLength, CopiesMaxLength)]
        public int Copies { get; set; }

        [Required]
        [MinLength(EditionMinLength)]
        [MaxLength(EditionMaxLength)]
        public string Edition { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int? AgeRestriction { get; set; }

        public Author Author { get; set; }

        public int AuthorId { get; set; }

        public List<CategoryBook> Categories { get; set; } = new List<CategoryBook>();
    }
}