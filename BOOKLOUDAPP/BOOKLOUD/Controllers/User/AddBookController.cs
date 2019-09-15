using System.Threading.Tasks;
using BOOKLOUD.Data;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.User
{
    [Authorize(Roles = "Admin, User")]
    public class AddBookController : Controller
    {
        private ApplicationDbContext _db;

        public AddBookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost] //post method
        public async Task<IActionResult> Create([Bind("Id, BookName, BookAuthor, BookEdition, BookIsbn, UniversityLocation, CourseName, UnitName, BookImage, BookPrice, BookDescription")] Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Add(book); //add data to Book table
                await _db.SaveChangesAsync(); //wait for database response
            }

            return RedirectToRoute("Default", new {Controller = "MyStore", Action = "MyBooks"});
        }
    }


}
