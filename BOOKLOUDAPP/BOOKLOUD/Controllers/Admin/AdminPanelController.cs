using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKLOUD.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
