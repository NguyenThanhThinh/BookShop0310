﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using BookShop0310.Data;
using BookShop0310.Data.Models;
using BookShop0310.Services.Models.Authors;
using Microsoft.EntityFrameworkCore;

namespace BookShop0310.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly BookShop0310DbContext _db;

        public AuthorService(BookShop0310DbContext db)
        {
            this._db = db;
        }

        public async Task CreateAsync(string firstName, string lastName)
        {
            var createAuthor = new Author
            {
                FirstName = firstName,
                LastName = lastName
            };

            await _db.Authors.AddAsync(createAuthor);

            await _db.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var result = await _db.Authors.AnyAsync(n => n.Id == id);

            return result;
        }

        public async Task<IEnumerable<GetBooksDetailsServiceModel>> GetBooksAsync(int authorId)
        {
            var books = await _db.Books.
                Where(n => n.AuthorId == authorId).
                ProjectTo<GetBooksDetailsServiceModel>()
                .ToListAsync();

            return books != null ? books : null;
        }

        public async Task<GetAuthorByIdServiceModel> GetByIdAsync(int id)
        {
            var result = await _db.Authors.
                ProjectTo<GetAuthorByIdServiceModel>().
                FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }
    }
}