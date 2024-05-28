﻿using BookCollection.Models;

namespace BookCollection.Services.Interfaces
{
    public interface IBookService
    {
        void Save(Book book); //Zapis do bazy danych
        IEnumerable<Book> GetAll();
        IEnumerable<Book> Search();
        IEnumerable<Book> TitleAToZ();
        IEnumerable<Book> TitleZToA();        
        IEnumerable<Book> AuthorAToZ();
        IEnumerable<Book> AuthorZToA();        
        IEnumerable<Book> GenreAToZ();
        IEnumerable<Book> GenreZToA();        
        IEnumerable<Book> YearAToZ();
        IEnumerable<Book> YearZToA();
        void Delete(List<int> ids);
    }
}
