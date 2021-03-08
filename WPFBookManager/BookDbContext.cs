using Microsoft.EntityFrameworkCore;
using WPFBookManager.Entities;

namespace WPFBookManager
{
    /// <summary>
    /// Main BookDbContext class
    /// </summary>
    public class BookDbContext : DbContext
    {
        /// <summary>
        /// Constructor of the BookDbContext class
        /// </summary>
        /// <param name="options"></param>
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
            // Creates database if one does not exist
            Database.EnsureCreated();
        }

        /// <summary>
        /// Property that contains table of Books
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Property that contains table of Authors
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Property that contains table of Genres
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Property that contains table of Publishers
        /// </summary>
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Book>().HasData(GetBooks());
            base.OnModelCreating(modelBuilder);
        }
    }
}
