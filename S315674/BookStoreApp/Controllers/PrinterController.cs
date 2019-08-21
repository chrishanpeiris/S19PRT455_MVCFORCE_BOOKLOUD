using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStoreApp.Controllers
{
    public class PrinterController : Controller
    {
        private readonly EfBridgeContext _db;

        public PrinterController(EfBridgeContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View(await _db.Printer.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Name, Brand, Model")] Printer printer)
        {
            if (ModelState.IsValid)
            {
                _db.Add(printer); //add data to Printer table
                await _db.SaveChangesAsync(); //wait for database response
                return RedirectToAction(nameof(Index)); // redirect to index
            }

            return View(printer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) //check if the id is null
            {
                return NotFound();
            }

            var printer = await _db.Printer.FindAsync(id); // search the id in Printer table
            if (printer == null)
            {
                return NotFound();
            }

            return View(printer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name, Brand, Model")] Printer printer)
        {
            if (id != printer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(printer); // update Printer name
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrinterExist(printer.Id))
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
            return View(printer);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printer = await _db.Printer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (printer == null)
            {
                return NotFound();
            }

            return View(printer);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var printer = await _db.Printer.FindAsync(id);
            _db.Printer.Remove(printer); // delete method 
            await _db.SaveChangesAsync(); // wait for the response from the backend
            return RedirectToAction(nameof(Index)); // redirect to index

        }

        public async Task<IActionResult> View(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printer = await _db.Printer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (printer == null)
            {
                return NotFound();
            }

            return View(printer);
        }

        private bool PrinterExist(int id)
        {
            return _db.Printer.Any(e => e.Id == id);
        }
    }
}
