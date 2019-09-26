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
            ViewBag.Units = _db.Unit.ToList();
            return View();
        }
        [HttpPost] //post method
        public async Task<IActionResult> AddUnit([Bind("Id, UnitName, UnitCode, UniversityId")] UnitDetailsViewModel Unit)
        {
            var universityId = Request.Form["UniversityId"];
            if (ModelState.IsValid)
            {
                _db.Add(Unit); //add data to Unit table
                await _db.SaveChangesAsync(); //wait for database response
                return RedirectToAction(nameof(UnitManagement)); // redirect to index
            }

            return View(Unit);
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
