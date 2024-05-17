using BookCollection.Models;
using BookCollection.Services.Interfaces;

namespace BookCollection.Services
{
    public class BookService : IBookService
    {
        private readonly DbBook _dbBook;
        public BookService(DbBook dbBook) 
        {
            _dbBook = dbBook;
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbBook.Books.ToList();
        }

        public void Save(Book book)
        {
            _dbBook.Add(book);
            _dbBook.SaveChanges();
        }
    }
}
