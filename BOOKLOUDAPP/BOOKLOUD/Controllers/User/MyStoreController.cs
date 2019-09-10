using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKLOUD.Data;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.User
{
    [Authorize(Roles = "Admin, User")]
    public class MyStoreController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MyStoreController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        
    }

        public IActionResult RecentActivities()
        {

            return View();
        }
        public IActionResult PurchaseHistory()
        {
            return View();
        }
        public IActionResult MyBooks()
        {
            return View();
        }
        public IActionResult ViewBooks()
        {
            var bookinfo = _db.Book.OrderBy(t=>t.BookName).
                Select(t => new ApplicationUser
                {
                    FirstName = t.BookName,
                      
                }).ToList();
            return View();
        }

        public IActionResult UpdateBooks()
        {
            return View();
        }

        public IActionResult DeleteBooks()
        {
            return View();
        }

    }


    
}
