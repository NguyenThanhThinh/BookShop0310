using System.Threading.Tasks;
using BookShop0310.Api.Infrastructure.Extensions;
using BookShop0310.Api.Infrastructure.Filters;
using BookShop0310.Api.Models.Books;
using BookShop0310.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop0310.Api.Controllers
{
    using static ApiConstants;

    public class BooksController : BaseController
    {
        private readonly IBookService _bookService;

        private readonly IAuthorService _authorService;

        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            this._bookService = bookService;

            this._authorService = authorService;
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> GetBookDetail(int id)
        {
            var getBookById = await _bookService.GetByIdAsync(id);

            return this.OkOrNotFound(getBookById);
        }

        public async Task<IActionResult> TopBooks([FromQuery] string search = "")
        {
            var getBookTitle = await _bookService.GetTopBooksByTitleAscendingAsync(search);

            return this.OkOrNotFound(getBookTitle);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody] CreateBookRequestModel bookModel)
        {
            if (!await _authorService.Exist(bookModel.AuthorId)) return BadRequest("Author does not exist");

            var id = await _bookService.Create(
                bookModel.Title,
                bookModel.Description,
                bookModel.Price,
                bookModel.Copies,
                bookModel.Edition,
                bookModel.AgeRestriction,
                bookModel.ReleaseDate,
                bookModel.CategoryNames,
                bookModel.AuthorId);

            return Ok(id);
        }

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> EditById(int id, [FromBody] EditBookByIdRequestModel bookModel)
        {
            var success = await _bookService.EditByIdAsync(
                id,
                bookModel.Title,
                bookModel.Description,
                bookModel.Price,
                bookModel.Copies,
                bookModel.Edition,
                bookModel.AgeRestriction,
                bookModel.ReleaseDate,
                bookModel.AuthorId);

            if (!success) return BadRequest();

            return Ok();
        }

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _bookService.Delete(id);

            if (!success) return BadRequest($"No book with Id {id}  exist. ");

            return this.OkOrNotFound(id);
        }
    }
}