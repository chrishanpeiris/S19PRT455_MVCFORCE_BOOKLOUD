using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BOOKLOUD.Data;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.User
{
    [Authorize(Roles = "Admin, User")]
    public class AddBookController : Controller
    {
        private ApplicationDbContext _db;
        private readonly IHostingEnvironment _appEnvironment;

        public AddBookController(ApplicationDbContext db, IHostingEnvironment appEnvironment)
        {
            _db = db;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {
            ViewBag.universities = _db.University.ToList();
            return View();
        }
        /*
        [HttpPost] //post method
        public async Task<IActionResult> Create([Bind("Id, BookName, BookAuthor, BookEdition, BookIsbn, UniversityLocation, CourseName, UnitName, BookImage, BookPrice, BookDescription")] Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Add(book); //add data to Book table
                await _db.SaveChangesAsync(); //wait for database response
            }

            return RedirectToRoute("Default", new {Controller = "MyStore", Action = "MyBooks"});
        }*/

        public JsonResult getcoursebyid(int id)
        {
            List<CourseDetailsModel> list = new List<CourseDetailsModel>();
            list = _db.Course.Where(a => a.University.Id == id).ToList();
            list.Insert(0, new CourseDetailsModel { Id = 0, CourseName = "Please Select Course" });
            return Json(new SelectList(list, "Id", "CourseName"));
        }


        public JsonResult getunitbyid(int id)
        {
            List<UnitDetailsModel> list = new List<UnitDetailsModel>();
            list = _db.Unit.Where(a => a.Course.Id == id).ToList();
            list.Insert(0, new UnitDetailsModel() { Id = 0, UnitName = "Please Select Course" });
            return Json(new SelectList(list, "Id", "UnitName"));
        }

        [HttpPost] //post method
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count == 0)
                {
                    book.BookImage = "book_image_not_available.png";
                }

                else
                {

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

                }
                _db.Add(book); //add data to Book table
                await _db.SaveChangesAsync(); //wait for database response
            }
            return RedirectToRoute("Default", new { Controller = "MyStore", Action = "MyBooks" });
        }
    }


}
