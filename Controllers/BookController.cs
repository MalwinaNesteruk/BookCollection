using BookCollection.Models;
using BookCollection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookCollection.Controllers
{
    public class BookController : Controller
    {
        public readonly IBookService _bookService;
        List<string> option = new List<string>()
        {
              "tytuł A-Z",
              "tytuł Z-A",
              "autor A-Z",
              "autor Z-A",
              "gatunek A-Z",
              "gatunek Z-A",
              "data wydania rosnąco",
              "data wydania malejąco"
        };

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
            SelectList selectOption = new SelectList(option);
            ViewBag.Book = selectOption;
            return View(_bookService.GetAll());
        }

        [HttpPost]
        public IActionResult GetAllBook(string sorting)
        {
            SelectList selectOption = new SelectList(option);
            ViewBag.Book = selectOption;
            if (sorting == "tytuł A-Z")
            {
                return View(_bookService.TitleAToZ());
            }

            else if (sorting == "tytuł Z-A")
            {
                return View(_bookService.TitleZToA());
            }

            else if (sorting == "autor A-Z")
            {
                return View(_bookService.AuthorAToZ());
            }

            else if (sorting == "autor Z-A")
            {
                return View(_bookService.AuthorZToA());
            }

            else if (sorting == "gatunek A-Z")
            {
                return View(_bookService.GenreAToZ());
            }

            else if (sorting == "gatunek Z-A")
            {
                return View(_bookService.GenreZToA());
            }

            else if (sorting == "data wydania rosnąco")
            {
                return View(_bookService.YearAToZ());
            }

            else if (sorting == "data wydania malejąco")
            {
                return View(_bookService.YearZToA());
            }

            return View(_bookService.GetAll());
        }

        [HttpGet]
        public IActionResult DeleteBook()
        {

            return View(_bookService.GetAll());
        }

        [HttpPost]
        public IActionResult DeleteBook([FromQuery] List<int> ids)
        {
            _bookService.Delete(ids);
            return RedirectToAction("DeleteBook", "Book");
        }

        [HttpGet]
        public IActionResult SearchBookForm()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchBookTable(string title = null, string name = null, string surname = null, string genre = null, int? year = null)
        {
            var result = _bookService.Search(title, name, surname, genre, year);
            return View(result);
        }
    }
}
