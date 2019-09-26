using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BOOKLOUD.BusinessLogicLayer.Services;
using BOOKLOUD.BusinessLogicLayer.Models;
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
        private BookService _businessLogicService;

        public AddBookController(ApplicationDbContext db, IHostingEnvironment appEnvironment, BookService businessLogicService)
        {
            _db = db;
            _appEnvironment = appEnvironment;
            _businessLogicService = businessLogicService;
        }

        public IActionResult Index()
        {
            ViewBag.universities = _db.University.ToList();
            return View();
        }
        /*
        [HttpPost] //post method
        public async Task<IActionResult> Create([Bind("Id, BookName, BookAuthor, BookEdition, BookIsbn, University, CourseName, UnitName, BookImage, BookPrice, BookDescription")] BookDetailsViewModel bookDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                _db.Add(bookDetailsViewModel); //add data to BookDetailsViewModel table
                await _db.SaveChangesAsync(); //wait for database response
            }

            return RedirectToRoute("Default", new {Controller = "MyStore", Action = "MyBooks"});
        }*/

        public JsonResult getcoursebyid(int id)
        {
            List<CourseDetailsViewModel> list =new List<CourseDetailsViewModel>();
            list = _db.Course.Where(a => a.University.Id == id).ToList();
            list.Insert(0, new CourseDetailsViewModel{Id=0, CourseName = "Please Select Course"});
            return Json(new SelectList(list, "Id", "CourseName"));
        }


        public JsonResult getunitbyid(int id)
        {
            List<UnitDetailsViewModel> list = new List<UnitDetailsViewModel>();
            list = _db.Unit.Where(a => a.Course.Id == id).ToList();
            list.Insert(0, new UnitDetailsViewModel() { Id = 0, UnitName = "Please Select Course" });
            return Json(new SelectList(list, "Id", "UnitName"));
        }


        [HttpPost] //post method
        public async Task<IActionResult> Create(BookDetailsViewModel bookDetailsViewModel)
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
                                bookDetailsViewModel.BookImage = fileName;
                            }

                        }
                    }
                }

                var BookBLLModel = new BookDetailsBLLModel();
                BookBLLModel.BookName = bookDetailsViewModel.BookName;
                BookBLLModel.BookAuthor = bookDetailsViewModel.BookAuthor;
                BookBLLModel.BookIsbn = bookDetailsViewModel.BookIsbn;
                BookBLLModel.BookEdition = bookDetailsViewModel.BookEdition;
                BookBLLModel.BookDescription = bookDetailsViewModel.BookDescription;
                BookBLLModel.BookImage = bookDetailsViewModel.BookImage;
                BookBLLModel.University = bookDetailsViewModel.University;
                BookBLLModel.CourseName = bookDetailsViewModel.CourseName;
                BookBLLModel.UnitName = bookDetailsViewModel.UnitName;
                BookBLLModel.BookPrice = bookDetailsViewModel.BookPrice;

                _businessLogicService.Add(BookBLLModel);


                //var files = HttpContext.Request.Form.Files;
                //foreach (var image in files)
                //{
                //    if (image != null && image.Length > 0)
                //    {
                //        var file = image;

                //        var uploads = Path.Combine(_appEnvironment.WebRootPath, "img\\book_img");
                //        if (file.Length > 0)
                //        {
                //            var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                //            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                //            {
                //                await file.CopyToAsync(fileStream);
                //                bookDetailsViewModel.BookImage = fileName;
                //            }

                //        }
                //    }
                //}
                //_db.Add(bookDetailsViewModel); //add data to BookDetailsViewModel table
                //await _db.SaveChangesAsync(); //wait for database response
            }
                return RedirectToRoute("Default", new { Controller = "MyStore", Action = "MyBooks" });
        }
    }


}
