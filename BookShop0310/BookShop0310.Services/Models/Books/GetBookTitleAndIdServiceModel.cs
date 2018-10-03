using BookShop0310.Common.Mapping;
using BookShop0310.Data.Models;

namespace BookShop0310.Services.Models.Books
{
    public class GetBookTitleAndIdServiceModel : IMapFrom<Book>
    {
        public string Title { get; set; }

        public int Id { get; set; }
    }
}
