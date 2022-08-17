using aspmvc.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
    }
}
