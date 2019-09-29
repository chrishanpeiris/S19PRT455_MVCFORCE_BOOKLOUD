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
    public class ManageUniversityController : Controller
    {
        private ApplicationDbContext _db;

        public ManageUniversityController(ApplicationDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
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

        public async Task<IActionResult> UniversityInfo(int id)
        {
            {
                if (id == null)
                {
                    return NotFound();
                }

                var university = await _db.University
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (university == null)
                {
                    return NotFound();
                }

                return View(university);
            }
        }

        public async Task<IActionResult> EditUniversity(int? id)
        {
            if (id == null) //check if the id is null
            {
                return NotFound();
            }

            var university = await _db.University.FindAsync(id); // search the id in Book table
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        [HttpPost]
        public async Task<IActionResult> EditUniversity(int id, [Bind("Id,UniversityName")] UniversityDetailsModel university)
        {
            if (id != university.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(university); // update Book name
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversityExist(university.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(UniversityManagement)); // redirect to index
            }
            return View(university);
        }

        private bool UniversityExist(int id)
        {
            return _db.University.Any(e => e.Id == id);
        }
    }
}
