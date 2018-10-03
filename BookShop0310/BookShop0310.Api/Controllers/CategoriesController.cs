using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop0310.Api.Infrastructure.Filters;
using BookShop0310.Api.Models.Categories;
using BookShop0310.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop0310.Api.Controllers
{
    using BookShop0310.Api.Infrastructure.Extensions;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var result = await categoryService.AllAsync();

            return this.OkOrNotFound(result);
        }

        [HttpPost]
        [ValidateModelState]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestModel model)
        {
            var idResult = await this.categoryService.Create(model.Name);

            if (idResult == 0)
            {
                return this.BadRequest($@"Category with Name: ""{model.Name}"" already exists.");
            }

            return this.Ok(idResult);
        }
    }
}