using System.Collections.Generic;
using System.Threading.Tasks;
using BookShop0310.Services.Models.Authors;

namespace BookShop0310.Services
{
    public interface IAuthorService
    {
        Task<GetAuthorByIdServiceModel> GetByIdAsync(int id);

        Task CreateAsync(string firstName, string lastName);

        Task<IEnumerable<GetBooksDetailsServiceModel>> GetBooksAsync(int authorId);

        Task<bool> Exist(int id);
    }
}