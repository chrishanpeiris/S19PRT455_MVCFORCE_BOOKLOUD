using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKLOUD.Data;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class ManageUnitController : Controller
    {
        private ApplicationDbContext _db;

        public ManageUnitController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public async Task<IActionResult> UnitManagement()
        {
            return View(await _db.Unit.ToListAsync());
        }

        public IActionResult AddUnit()
        {
            ViewBag.universities = _db.University.ToList();
            return View();
        }

        [HttpPost] //post method
        public async Task<IActionResult> AddUnit([Bind("Id, UnitCode, UnitName, CourseId, UniversityId ")]UnitDetailsViewModel unit)
        {
            if (ModelState.IsValid)
            {

                var newUnit = new UnitDetailsModel()
                {
                    Id = unit.Id,
                    UnitName = unit.UnitName,
                    UnitCode = unit.UnitCode,
                    Course = _db.Course.Find(unit.UniversityId),
                    University = _db.University.Find(unit.UniversityId)
                };

                _db.Add(newUnit); //add data to University table
                await _db.SaveChangesAsync(); //wait for database response
                return RedirectToAction(nameof(UnitManagement)); // redirect to index
            }

            return View(unit);
        }

        public JsonResult getcoursebyid(int id)
        {
            List<CourseDetailsModel> list = new List<CourseDetailsModel>();
            list = _db.Course.Where(a => a.University.Id == id).ToList();
            list.Insert(0, new CourseDetailsModel { Id = 0, CourseName = "Please Select Course" });
            return Json(new SelectList(list, "Id", "CourseName"));
        }

        public async Task<IActionResult> UnitInfo(int id)
        {
            {
                if (id == null)
                {
                    return NotFound();
                }

                var unit = await _db.Unit
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (unit == null)
                {
                    return NotFound();
                }

                return View(unit);
            }
        }

    }
}
