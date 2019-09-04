using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKLOUD.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.Shared
{
    public class AddBookController : Controller
    {
        private ApplicationDbContext _db;

        public AddBookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost] //post method
        public async Task<IActionResult> Create([Bind("Id, BookName, BookAuthor, BookEdition, BookISBN, UniversityLocation, CourseName, UnitName, BookImage, BookPrice, BookDescription")] Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Add(book); //add data to Book table
                await _db.SaveChangesAsync(); //wait for database response
            }

            return RedirectToRoute("Default", new {Controller = "User", Action = "ListedBooks"});
        }
    }


}
