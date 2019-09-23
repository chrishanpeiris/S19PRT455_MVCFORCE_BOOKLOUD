using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BOOKLOUD.Data;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.Admin
{

    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private ApplicationDbContext _db;

        public AdminPanelController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserManagement()
        {
            return View(await _db.Users.ToListAsync());
        }

        public async Task<IActionResult> UserInfo(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public async Task<IActionResult> UnitManagement()
        {
            return View(await _db.Unit.ToListAsync());
        }

        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult AddUnit()
        {
            return View();
        }

        public IActionResult Edit()
        {
            throw new NotImplementedException();
        }

        public IActionResult Details()
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }

        //actions for university management tasks
        public async Task<IActionResult> UniversityManagement()
        {
            return View(await _db.University.ToListAsync());
        }

        public IActionResult AddUniveristy()
        {
            return View();
        }
        [HttpPost] //post method
        public async Task<IActionResult> AddUniveristy(UniversityDetailsModel university)
        {
            if (ModelState.IsValid)
            {
                _db.Add(university); //add data to University table
                await _db.SaveChangesAsync(); //wait for database response
                return RedirectToAction(nameof(UniversityManagement)); // redirect to index
            }

            return View(university);
        }


        //actions for course management tasks
        public async Task<IActionResult> CourseManagement()
        {
            return View(await _db.Course.ToListAsync());
        }

        public IActionResult AddCourse()
        {
            ViewBag.universities = _db.University.ToList();
            return View();
        }

        [HttpPost] //post method
        public async Task<IActionResult> AddCourse([Bind("Id, CourseName, UniversityId")]CourseDetailsModel course)
        {
            var universityId = Request.Form["UniversityId"];
            if (ModelState.IsValid)
            {
                /*
                var newCourse = new CourseDetailsModel()
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    University = universityId
                }; */
                // course.University = HttpContext.Request.Form["UserName"].ToString();
                //HttpContext.Items["UniversityList"] = HttpContext.Request.Form["UniversityList"];
                //StringValues universityId = HttpContext.Request.Form["UniversityList"];
                //course.University = universityId;
                _db.Add(course); //add data to University table
                await _db.SaveChangesAsync(); //wait for database response
                return RedirectToAction(nameof(CourseManagement)); // redirect to index
            }

            return View(course);
        }

    }
}
