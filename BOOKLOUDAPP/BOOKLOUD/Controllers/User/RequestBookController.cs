using BOOKLOUD.Data;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.User
{
    [Authorize(Roles = "Admin, User")]
    public class RequestBookController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IHostingEnvironment _appEnvironment;

        public RequestBookController(ApplicationDbContext db, IHostingEnvironment appEnvironment)
        {
            _db = db;
            _appEnvironment = appEnvironment;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RequestBook()
        {
            return View();
        }
        [HttpPost] //post method
        public async Task<IActionResult> RequestBook(Book book)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                foreach (var image in files)
                {
                    if (image != null && image.Length > 0)
                    {
                        var file = image;

                        var uploads = Path.Combine(_appEnvironment.WebRootPath, "img\\book_img");
                        if (file.Length > 0)
                        {
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                book.BookImage = fileName;
                            }

                        }
                    }
                }
                _db.Add(book); //add data to Book table
                await _db.SaveChangesAsync(); //wait for database response
            }
            return RedirectToRoute("Default", new { Controller = "MyStore", Action = "MyBooks" });
        }
    }
}
