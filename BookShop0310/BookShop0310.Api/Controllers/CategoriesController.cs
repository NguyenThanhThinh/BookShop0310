using System.Threading.Tasks;
using BookShop0310.Api.Infrastructure.Extensions;
using BookShop0310.Api.Infrastructure.Filters;
using BookShop0310.Api.Models.Categories;
using BookShop0310.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop0310.Api.Controllers
{
    using static ApiConstants;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var result = await _categoryService.AllAsync();

            return this.OkOrNotFound(result);
        }

        [HttpGet(WithId)]
        public async Task<IActionResult> GetById(int id)
        {
            var getCategoryById = await _categoryService.GetByIdAsync(id);

            return this.OkOrNotFound(getCategoryById);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestModel model)
        {
            var idResult = await _categoryService.Create(model.Name);

            if (idResult == 0) return BadRequest($@"Category with Name: ""{model.Name}"" already exists.");

            return Ok(idResult);
        }

        [HttpPut(WithId)]
        [ValidateModelState]
        public async Task<IActionResult> Edit(int id, [FromBody] EditCategoryNameRequestModel model)
        {
            var success = await _categoryService.EditNameByIdAsync(id, model.Name);

            if (!success)
                return BadRequest($@"Category with Id {id} does not exist or Name: ""{model.Name}"" already exists.");

            return Ok(await GetById(id));
        }

        [HttpDelete(WithId)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _categoryService.Delete(id);

            if (!success) return BadRequest($"Category with Id {id} does not exist");

            return Ok("Deleted");
        }
    }
}