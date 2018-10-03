using BookShop0310.Common.Mapping;
using BookShop0310.Data.Models;

namespace BookShop0310.Services.Models.Categories
{
    public class GetCategoryIdAndNameModelService : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}