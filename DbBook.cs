using BookCollection.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCollection
{
    public class DbBook : DbContext
    {
        public DbBook(DbContextOptions<DbBook> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; } // tworzenie tabeli o nazwie Books

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
