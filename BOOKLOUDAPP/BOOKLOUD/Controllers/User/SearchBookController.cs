using System;
using System.Linq;
using System.Threading.Tasks;
using BOOKLOUD.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.User
{
    public class SearchBookController : Controller
    {
        private ApplicationDbContext _db;

        public SearchBookController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        /*public IActionResult Index()
        {
            return View();
        }*/

        public async Task<IActionResult> Index(string searchString)
        {
            var books = from b in _db.Book
                select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.BookName.Contains(searchString));
            }

            return View(await books.ToListAsync());
        }
    }

}
