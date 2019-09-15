using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BOOKLOUD.Data;
using Microsoft.AspNetCore.Mvc;

namespace BOOKLOUD.Controllers.Api
{

    [Route("api/book")]
    public class SearchApiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SearchApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();
                var names = _db.Book.Where(b => b.BookName.Contains(term)).Select(b => new
                {
                    id = b.Id,
                    label = b.BookName,
                    value = b.BookName,
                    imgPath = b.BookImage

                }).ToList();
                return Ok(names);
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}