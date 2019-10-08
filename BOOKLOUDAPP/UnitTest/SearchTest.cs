using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BOOKLOUD.Controllers.User;
using BOOKLOUD.Data;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class SearchTest
    {
        private SearchBookController _searchBook;
        private ApplicationDbContext _dbContext;

        public SearchTest(SearchBookController searchBook, ApplicationDbContext dbContext)
        {
            _searchBook = searchBook;
            _dbContext = dbContext;
        }
        [Test]
        public async Task<IActionResult> Test_Search_With_Valid_Keyword()
        {
            var request = await _searchBook.Index("iot");
            Assert.AreEqual("iot", request);

            return null;
        }

        [Ignore("Ignore Test")]
        public void Test_To_Ignore()
        {

        }
    }
}
