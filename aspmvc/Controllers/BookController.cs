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

        //http get Index
        public IActionResult Index()
        {
            IEnumerable<Book> books = _appDbContext.Books;
            return View(books);
        }


        //http get Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Books.Add(book);
                _appDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit()
        {

            return View();
        }

        public IActionResult Delete()
        {

            return View();
        }
    }
}
