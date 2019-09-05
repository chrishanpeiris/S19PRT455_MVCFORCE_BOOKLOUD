using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.Admin
{

    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserManagement()
        {
            return View();
        }

        public IActionResult UserInfo()
        {
            return View();
        }

        public IActionResult UnitManagement()
        {
            return View();
        }

        public IActionResult Reports()
        {
            return View();
        }
    }
}
