using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreApp.Controllers
{
    public class BookController : Controller
    {
        private readonly EfBridgeContext _db; //create a private variable

        public BookController(EfBridgeContext db) //create a constructor and pass the dbcontext from DAL folder
        {
            _db = db; //assign private variable to reference 
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _db.Book.ToListAsync()); //read data from Book table
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //post method
        public async Task<IActionResult> Create([Bind("Id,Name")] Book book)
        {
            if (ModelState.IsValid)
            {
                _db.Add(book); //add data to Book table
                await _db.SaveChangesAsync(); //wait for database response
                return RedirectToAction(nameof(Index)); // redirect to index
            }

            return View(book);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) //check if the id is null
            {
                return NotFound();
            }

            var book = await _db.Book.FindAsync(id); // search the id in Book table
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Book book) 
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(book); // update Book name
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooksExist(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // redirect to index
            }
            return View(book);
        }

        public async Task<IActionResult> Delete(int? id)
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

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _db.Book.FindAsync(id);
            _db.Book.Remove(book); // delete method 
            await _db.SaveChangesAsync(); // wait for the response from the backend
            return RedirectToAction(nameof(Index)); // redirect to index

        }

        public async Task<IActionResult> View(int? id)
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

        private bool BooksExist(int id)
        {
            return _db.Book.Any(e => e.Id == id);
        }
    }
}
