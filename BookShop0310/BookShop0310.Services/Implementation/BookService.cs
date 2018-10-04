using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BookShop0310.Data;
using BookShop0310.Data.Models;
using BookShop0310.Services.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace BookShop0310.Services.Implementation
{
    public class BookService : IBookService
    {
        private readonly BookShop0310DbContext _db;

        public BookService(BookShop0310DbContext db)
        {
            this._db = db;
        }

        public async Task<int> Create(string title, string description, double price, int copies, string edition,
            int? ageRestriction, DateTime releaseDate, string categoryNames, int authorId)
        {
            var splitCategoryNames = categoryNames
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToHashSet();

            var existingCategories = await _db
                .Categories
                .Where(ct => splitCategoryNames
                    .Contains(ct.Name))
                .ToListAsync();

            var allCategories = new List<Category>(existingCategories);

            CreateAndAddNonExistingCategories(splitCategoryNames, existingCategories, allCategories);

            await _db.SaveChangesAsync();

            var book = new Book
            {
                Title = title,
                Description = description,
                Price = price,
                Copies = copies,
                Edition = edition,
                AgeRestriction = ageRestriction,
                ReleaseDate = releaseDate,
                AuthorId = authorId
            };

            allCategories.ForEach(c => book.Categories.Add(new CategoryBook
            {
                CategoryId = c.Id
            }));

            await _db.Books.AddAsync(book);

            await _db.SaveChangesAsync();

            return book.Id;
        }

        public async Task<bool> Delete(int id)
        {
            var book = _db.Books.FirstOrDefaultAsync(n => n.Id == id);

            if (book == null) return false;

            _db.Remove(book);

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditByIdAsync(int id, string title, string description, double price, int copies,
            string edition, int? ageRestriction, DateTime releaseDate, int authorId)
        {
            var book = await _db.Books
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null) return false;

            book.Title = title;

            book.Description = description;

            book.Price = price;

            book.Copies = copies;

            book.Edition = edition;

            book.AgeRestriction = ageRestriction;

            book.ReleaseDate = releaseDate;

            book.AuthorId = authorId;

            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<GetBooksByIdServiceModel>> GetByIdAsync(int id)
        {
            var getBookById = await _db.Books.Where(n => n.Id == id).ProjectTo<GetBooksByIdServiceModel>().ToListAsync();

            return getBookById != null ? getBookById : null;
        }

        public async Task<IEnumerable<GetBookTitleAndIdServiceModel>> GetTopBooksByTitleAscendingAsync(string search)
        {
            var result = await _db.Books
                .Where(b => b.Description.ToLower()
                                .Contains(search.ToLower()) ||
                            b.Title.ToLower()
                                .Contains(search.ToLower()))
                .OrderBy(t => t.Title)
                .Take(10)
                .ProjectTo<GetBookTitleAndIdServiceModel>()
                .ToListAsync();

            return result;
        }

        private void CreateAndAddNonExistingCategories(HashSet<string> splitCategoryNames,
            List<Category> existingCategories,
            List<Category> allCategories)
        {
            foreach (var categoryName in splitCategoryNames)

                if (existingCategories.All(c => c.Name != categoryName))
                {
                    var category = new Category
                    {
                        Name = categoryName
                    };

                    allCategories.Add(category);

                    _db.Categories.Add(category);
                }
        }
    }
}