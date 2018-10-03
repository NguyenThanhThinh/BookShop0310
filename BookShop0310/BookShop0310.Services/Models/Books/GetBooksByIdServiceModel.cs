using System.Linq;
using AutoMapper;
using BookShop0310.Common.Mapping;
using BookShop0310.Data.Models;
using BookShop0310.Services.Models.Authors;

namespace BookShop0310.Services.Models.Books
{
    public class GetBooksByIdServiceModel : GetBooksDetailsServiceModel, IMapFrom<Book>, IHaveCustomMapping
    {
        public override void ConfigureMapping(Profile mapper)
        {
            mapper.CreateMap<Book, GetBooksByIdServiceModel>()
                .ForMember(b => b.Author, cfg => cfg
                    .MapFrom(b => b.Author.FirstName + " " + b.Author.LastName))
                .ForMember(b => b.Categories, cfg => cfg
                    .MapFrom(b => b.Categories
                        .Select(c => c.Category.Name)));
        }
    }
}