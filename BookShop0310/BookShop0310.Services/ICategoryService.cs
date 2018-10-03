using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop0310.Services.Models.Categories;

namespace BookShop0310.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryIdAndNameModelService>> AllAsync();

        Task<GetCategoryIdAndNameModelService> GetByIdAsync(int id);

        Task<bool> EditNameByIdAsync(int id, string name);

        Task<bool> Delete(int id);

        Task<int> Create(string name);
    }
}