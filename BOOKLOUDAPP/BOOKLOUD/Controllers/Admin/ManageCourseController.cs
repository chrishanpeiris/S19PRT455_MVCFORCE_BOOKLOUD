﻿using System;
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