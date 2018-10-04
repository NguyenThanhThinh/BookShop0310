using System.Threading.Tasks;
using BookShop0310.Api.Infrastructure.Extensions;
using BookShop0310.Api.Infrastructure.Filters;
using BookShop0310.Api.Models.Authors;
using BookShop0310.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop0310.Api.Controllers
{
    using static ApiConstants;

    public class AuthorsController : BaseController
    {
        private readonly IAuthorService authorService;

        public AuthorsController(IAuthorService authorService)
        {
            this.authorService = authorService;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> GetById(int id)
        {
            var getAuthorById = await authorService.GetByIdAsync(id);

            return this.OkOrNotFound(getAuthorById);
        }

        [HttpGet(WithId + "/books")]
        public async Task<IActionResult> Books(int id)
        {
            var getBook = await authorService.GetBooksAsync(id);

            return this.OkOrNotFound(getBook);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromBody] PostAuthorRequestModel authorModel)
        {
            await authorService.CreateAsync(authorModel.FirstName, authorModel.LastName);

            return Ok(authorModel);
        }
    }
}