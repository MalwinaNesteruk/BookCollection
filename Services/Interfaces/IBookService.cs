using BookCollection.Models;

namespace BookCollection.Services.Interfaces
{
    public interface IBookService
    {
        void Save(Book book); //Zapis do bazy danych
        IEnumerable<Book> GetAll();
    }
}
