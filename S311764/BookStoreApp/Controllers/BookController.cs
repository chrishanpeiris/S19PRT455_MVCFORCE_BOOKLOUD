using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreApp.Controllers
{
    public class BookController : Controller
    {
        private readonly EfBridgeContext _db;

        public BookController(EfBridgeContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _db.Book.ToListAsync());
        }
    }
}
