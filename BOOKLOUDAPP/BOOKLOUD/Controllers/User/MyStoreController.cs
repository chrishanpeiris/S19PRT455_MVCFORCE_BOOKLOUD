using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKLOUD.Data;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BOOKLOUD.Controllers.User
{
    [Authorize(Roles = "Admin, User")]
    public class MyStoreController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _appEnvironment;

        public MyStoreController(ApplicationDbContext db, IHostingEnvironment appEnvironment)
        {
            _db = db;
            _appEnvironment = appEnvironment;
        }

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
        public async Task<IActionResult> MyBooks()
        {
            return View(await _db.Book.ToListAsync());
        }
        public async Task<IActionResult> ViewBooks(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _db.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult UpdateBooks()
        {
            return View();
        }

        public IActionResult DeleteBooks()
        {
            return View();
        }

        // GET: EditBooks
        public async Task<IActionResult> EditBooks(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _db.Book.SingleOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            string webRoot = _appEnvironment.WebRootPath;
            string img_p = "";
            string fileName = "";
            if (System.IO.Directory.Exists(webRoot + "/img/" + "/book_img/"))
            {
                string[] strfiles = Directory.GetFiles(webRoot + "/img/"  + "/book_img/", "*.*");

                if (strfiles.Length > 0)
                {

                    for (int i = 0; i < strfiles.Length; i++)
                    {
                        fileName = Path.GetFileName(strfiles[i]);

                        string _CurrentFile = strfiles[i].ToString();
                        if (System.IO.File.Exists(_CurrentFile))
                        {
                            string tempFileURL = "/img/"  + "/book_img/" + Path.GetFileName(_CurrentFile);
                            img_p = tempFileURL;
                        }

                    }

                }
            }
            if (!string.IsNullOrEmpty(img_p))
            {
                ViewBag.ImgPath = Convert.ToString(img_p);
                ViewBag.FileName = Convert.ToString(fileName);
            }
            else
                ViewBag.ImgPath = "/book_img/default.jpg";

            return View(book);
        }

        // POST: EditBooks
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBooks(int id, [Bind("Id,BookName,BookAuthor,BookEdition,BookIsbn,University,BookImage,CourseName,UnitName,BookPrice,BookDescription")] BookDetailsViewModel bookDetailsViewModel)
        {
            if (id != bookDetailsViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(bookDetailsViewModel);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(bookDetailsViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MyBooks));
            }           
            return View(bookDetailsViewModel);
        }
        // GET: Books Remove
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _db.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books Remove
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _db.Book.FindAsync(id);
            _db.Book.Remove(book);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool BookExists(int id)
        {
            return _db.Book.Any(e => e.Id == id);
        }

    }



}
