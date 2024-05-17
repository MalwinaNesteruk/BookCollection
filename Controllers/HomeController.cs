using BookCollection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookCollection.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
