using aspmvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace aspmvc.Controllers
{
    public class BookController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public BookController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = _appDbContext.Books;
            return View(books);
        }
    }
}
