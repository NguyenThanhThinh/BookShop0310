using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BookShop0310.Common.Mapping;
using BookShop0310.Data.Models;

namespace BookShop0310.Services.Models.Authors
{
    public class GetAuthorByIdServiceModel : IMapFrom<Author>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<string> BookTitles { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Author, GetAuthorByIdServiceModel>()
                .ForMember(a => a.BookTitles, cfg => cfg
                    .MapFrom(a => a.Books
                        .Select(b => b.Title)));
        }
    }
}