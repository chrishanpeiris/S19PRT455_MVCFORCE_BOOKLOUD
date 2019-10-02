using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKLOUD.Data;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class ManageCourseController : Controller
    {
        private ApplicationDbContext _db;

        public ManageCourseController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
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
        public async Task<IActionResult> AddCourse([Bind("Id, CourseName, UniversityId")]CourseDetailsViewModel course)
        {
            if (ModelState.IsValid)
            {

                var newCourse = new CourseDetailsModel()
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    University = _db.University.Find(course.UniversityId)
                };

                _db.Add(newCourse); //add data to University table
                await _db.SaveChangesAsync(); //wait for database response
                return RedirectToAction(nameof(CourseManagement)); // redirect to index
            }

            return View(course);
        }

        public async Task<IActionResult> CourseInfo(int id)
        {
            {
                if (id == null)
                {
                    return NotFound();
                }

                var course = await _db.Course
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (course == null)
                {
                    return NotFound();
                }

                return View(course);
            }
        }

        public async Task<IActionResult> EditCourse(int? id)
        {
            if (id == null) //check if the id is null
            {
                return NotFound();
            }

            var course = await _db.Course.FindAsync(id); // search the id in Book table
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> EditCourse(int id, [Bind("Id,CourseName, UniversityId")] CourseDetailsModel course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(course); // update Book name
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExist(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(CourseManagement)); // redirect to index
            }
            return View(course);
        }

        public async Task<IActionResult> DeleteCourse(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _db.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("DeleteCourse")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _db.Course.FindAsync(id);
            _db.Course.Remove(course); // delete method 
            await _db.SaveChangesAsync(); // wait for the response from the backend
            return RedirectToAction(nameof(CourseManagement)); // redirect to index

        }

        private bool CourseExist(int id)
        {
            return _db.Course.Any(e => e.Id == id);
        }
    }
}
