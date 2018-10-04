using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BookShop0310.Data;
using BookShop0310.Data.Models;
using BookShop0310.Services.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace BookShop0310.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly BookShop0310DbContext _db;

        public CategoryService(BookShop0310DbContext db)
        {
            this._db = db;
        }

        public async Task<IEnumerable<GetCategoryIdAndNameModelService>> AllAsync()
        {
            var result = await _db.Categories.ProjectTo<GetCategoryIdAndNameModelService>().ToListAsync();

            return result;
        }

        public async Task<int> Create(string name)
        {
            var exists = await _db.Categories
                .AnyAsync(c => c.Name == name);

            if (exists) return 0;

            var category = new Category
            {
                Name = name
            };

            await _db.Categories.AddAsync(category);

            await _db.SaveChangesAsync();

            return category.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(n => n.Id == id);

            if (category == null) return false;

            _db.Categories.Remove(category);

            _db.SaveChanges();

            return true;
        }

        public async Task<bool> EditNameByIdAsync(int id, string name)
        {
            var exists = await _db.Categories.AnyAsync(n => n.Name == name);

            var category = await _db.Categories.FirstOrDefaultAsync(n => n.Id == id);

            if (category == null || exists) return false;

            category.Name = name;

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<GetCategoryIdAndNameModelService> GetByIdAsync(int id)
        {
            var getCategoryById = await _db.Categories
                .ProjectTo<GetCategoryIdAndNameModelService>().FirstOrDefaultAsync(n => n.Id == id);

            return getCategoryById != null ? getCategoryById : null;
        }
    }
}