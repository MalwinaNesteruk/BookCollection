using BookCollection.Models;
using BookCollection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookCollection.Controllers
{
    public class BookController : Controller
    {
        public readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet] //generuje formularz
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost] //tutaj powinien być zawsze jakiś parametr przyjmowany
        public IActionResult AddBook(Book book) 
        {

            if (!ModelState.IsValid) //sprawdza, czy w formularzu wszystkie pola wypełnione 
            {
                return View(book); //zwraca widok z zapamiętanymi danymi wpisanymi przez użytkownika
            }
            _bookService.Save(book);
            return RedirectToAction("AddBook"); //powrót do metody add, "czyszczą się" pola w formularzu
        }

        [HttpGet]
        public IActionResult GetAllBook() 
        {

            return View(_bookService.GetAll());
        }
    }
}
