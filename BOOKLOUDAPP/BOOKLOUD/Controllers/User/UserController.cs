﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.User
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        
    }

        public IActionResult RecentActivities()
        {

            return View();
        }
        public IActionResult PurchaseHistory()
        {

            return View();
        }
        public IActionResult ListedBooks()
        {
            return View();
        }
        public IActionResult ViewBooks()
        {
            return View();
        }

        public IActionResult UpdateBooks()
        {
            return View();
        }

        public IActionResult RemoveBooks()
        {
            return View();
        }

    }


    
}
