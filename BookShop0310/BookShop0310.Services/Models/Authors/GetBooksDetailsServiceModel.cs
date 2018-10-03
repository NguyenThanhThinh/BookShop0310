using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookShop0310.Common.Mapping;
using BookShop0310.Data.Models;

namespace BookShop0310.Services.Models.Authors
{
    public class GetBooksDetailsServiceModel : IMapFrom<Book>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Copies { get; set; }

        public string Edition { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? AgeRestriction { get; set; }

        public string Author { get; set; }

        public List<string> Categories { get; set; } = new List<string>();

        public virtual void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Book, GetBooksDetailsServiceModel>()
                .ForMember(b => b.Author, cfg => cfg
                    .MapFrom(b => b.Author.FirstName + " " + b.Author.LastName))
                .ForMember(b => b.Categories, cfg => cfg
                    .MapFrom(b => b.Categories
                        .Select(c => c.Category.Name)));
        }
    }
}