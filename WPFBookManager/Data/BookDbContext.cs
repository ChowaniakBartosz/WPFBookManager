using Microsoft.EntityFrameworkCore;
using System;

namespace WPFBookManager.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(GetBooks());
            base.OnModelCreating(modelBuilder);
        }

        private Book[] GetBooks()
        {
            return new Book[]
            {
                new Book { Id = 1, Title = "Permanent Record", Author = "Edward Snowden", Publisher = "Metropolitan Books", Genre = "Biography", Year = 2019, Pages = 352 },
                new Book { Id = 2, Title = "Atomic Habits", Author = "James Clear", Publisher = "Avery", Genre = "Psychology", Year = 2018, Pages = 320 },
                new Book { Id = 3, Title = "The War of Art", Author = "Steven Pressfield", Publisher = "Black Irish Entertainment", Genre = "Psychology", Year = 2012, Pages = 190 },
                new Book { Id = 4, Title = "Deep Work", Author = "Cal Newport", Publisher = "Grand Central Publishing", Genre = "Self-Help", Year = 2016, Pages = 304 }
            };
        }
    }
}
