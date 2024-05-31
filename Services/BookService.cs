using BookCollection.Models;
using BookCollection.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

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

        public IEnumerable<Book> Search(string title = null, string name = null, string surname = null, string genre = null, int? year = null)
        {
            return _dbBook.Books.Where(x => (x.Title == title || title == null)
                                            && (x.NameAuthor == name || name == null)
                                            && (x.SurnameAuthor == surname || surname == null)
                                            && (x.Genre == genre || genre == null)
                                            && (x.YearOfPublication == year || year == null)).ToList();
        }

        public void Save(Book book)
        {
            _dbBook.Add(book);
            _dbBook.SaveChanges();
        } 
        
        public void Delete(List<int> ids)
        {
            var dbBook = _dbBook.Books.Where(x => ids.Contains(x.Id)).ToList();
            _dbBook.Books.RemoveRange(dbBook);
            _dbBook.SaveChanges();
        }

        public IEnumerable<Book> TitleAToZ()
        {
            return _dbBook.Books.OrderBy(x => x.Title).ToList();
        }
        
        public IEnumerable<Book> TitleZToA()
        {
            return _dbBook.Books.OrderByDescending(x => x.Title).ToList();
        }        
        
        public IEnumerable<Book> AuthorAToZ()
        {
            return _dbBook.Books.OrderBy(x => x.SurnameAuthor).ToList();
        }        
        
        public IEnumerable<Book> AuthorZToA()
        {
            return _dbBook.Books.OrderByDescending(x => x.SurnameAuthor).ToList();
        }        
        
        public IEnumerable<Book> GenreAToZ()
        {
            return _dbBook.Books.OrderBy(x => x.Genre).ToList();
        }        
        
        public IEnumerable<Book> GenreZToA()
        {
            return _dbBook.Books.OrderByDescending(x => x.Genre).ToList();
        }        
        
        public IEnumerable<Book> YearAToZ()
        {
            return _dbBook.Books.OrderBy(x => x.YearOfPublication).ToList();
        }        
        
        public IEnumerable<Book> YearZToA()
        {
            return _dbBook.Books.OrderByDescending(x => x.YearOfPublication).ToList();
        }
    }
}
