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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Books.Add(book);
                _appDbContext.SaveChanges();
                TempData["Mensaje"] = "El Libro ha sido creado Correctamente";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id is null || id == 0)
                return NotFound();
            
            var book = _appDbContext.Books.Find(id);
            
            if(book is null)
                return NotFound();
                
            return View(book);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            { 
                _appDbContext.Books.Update(book);
                _appDbContext.SaveChanges();
                TempData["Mensaje"] = "Ël libro ha sido actualizado";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id is null || id == 0)
                return NotFound();

            var book = _appDbContext.Books.Find(id);

            if (book is null)
                return NotFound();

            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Book book)
        {
            var bookDelete = _appDbContext.Books.Find(book.Id);
            if (bookDelete is null)
                return NotFound();

            _appDbContext.Books.Remove(bookDelete);
            _appDbContext.SaveChanges();
            TempData["Mensaje"] = "El libro ha sido ELiminado";
            return RedirectToAction("Index");

        }
    }
}
