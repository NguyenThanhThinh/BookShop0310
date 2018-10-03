using BookShop0310.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookShop0310.Data
{
    public class BookShop0310DbContext : DbContext
    {
        public BookShop0310DbContext(DbContextOptions<BookShop0310DbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CategoryBook> CategoryBooks { get; set; }

        public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<BookShop0310DbContext>
        {
            BookShop0310DbContext IDesignTimeDbContextFactory<BookShop0310DbContext>.CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<BookShop0310DbContext>();
                optionsBuilder.UseSqlServer<BookShop0310DbContext>("Server=NTTHINH-PC\\SQL2K14;Database=BookShopDb0310;Integrated Security=true;Trusted_Connection=True;MultipleActiveResultSets=true");

                return new BookShop0310DbContext(optionsBuilder.Options);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId);

            builder.Entity<CategoryBook>().HasKey(cb => new {cb.BookId, cb.CategoryId});

            builder.Entity<CategoryBook>()
                .HasOne(cb => cb.Book)
                .WithMany(b => b.Categories)
                .HasForeignKey(cb => cb.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CategoryBook>()
                .HasOne(cb => cb.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(cb => cb.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CategoryBook>().ToTable("CategoriesBooks");
        }
    }
}