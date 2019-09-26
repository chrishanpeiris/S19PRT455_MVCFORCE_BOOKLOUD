using System;
using System.Collections.Generic;
using System.Text;
using BOOKLOUD.DataAccessLayer.DataContext;
using BOOKLOUD.DataAccessLayer.Interfaces;
using BOOKLOUD.DataAccessLayer.Models;
using Microsoft.AspNetCore.Hosting;

namespace BOOKLOUD.DataAccessLayer.Services
{
    public class BookDataAccessService : IBookDataAccessService
    {
        private BookCloudDbContext _dbContext;
        private IHostingEnvironment _appEnvironment;

        public BookDataAccessService(BookCloudDbContext dbContext, IHostingEnvironment appEnvironment)
        {
            _dbContext = dbContext;
            _appEnvironment = appEnvironment;
        }


        public void AddBook(BookDetailsDALModel model)
        {
            _dbContext.Add(model); //add data to BookDetailsViewModel table
            _dbContext.SaveChanges(); //wait for database response
        }
    }
}
