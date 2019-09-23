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
    }
}
