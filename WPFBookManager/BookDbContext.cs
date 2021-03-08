using Microsoft.EntityFrameworkCore;
using System;
using WPFBookManager.Entities;

namespace WPFBookManager
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasData(GetBooks());
            base.OnModelCreating(modelBuilder);
        }

        //private Book[] GetBooks()
        //{
        //    return new Book[]
        //    {
        //        new Book { Id = 1, Title = "Permanent Record", Author = new { Name = "Edward Snowden" }, Publisher = { Name = "Metropolitan Books" }, Genre = { Name = "Biography" }, Year = 2019, Pages = 352 },
        //        new Book { Id = 2, Title = "Atomic Habits", Author = { Name = "James Clear" }, Publisher = { Name = "Avery" }, Genre = { Name = "Psychology" }, Year = 2018, Pages = 320 },
        //        new Book { Id = 3, Title = "The War of Art", Author = { Name = "Steven Pressfield" }, Publisher = { Name = "Black Irish Entertainment" }, Genre = { Name = "Psychology" }, Year = 2012, Pages = 190 },
        //        new Book { Id = 4, Title = "Deep Work", Author = { Name = "Cal Newport" }, Publisher = { Name = "Grand Central Publishing" }, Genre = { Name = "Self-Help" }, Year = 2016, Pages = 304 }
        //    };
        //}
    }
}
