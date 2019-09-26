using System;
using System.Collections.Generic;
using System.Text;
using BOOKLOUD.BusinessLogicLayer.Interfaces;
using BOOKLOUD.BusinessLogicLayer.Models;
using BOOKLOUD.DataAccessLayer.Models;
using BOOKLOUD.DataAccessLayer.Services;

namespace BOOKLOUD.BusinessLogicLayer.Services
{
    public class BookService : IBookService
    {
        private BookDataAccessService _dataAccessService;

        public BookService(BookDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;

        }

        public void Add(BookDetailsBLLModel bookDetailsBLLModel)
        {
            var BookDALModel = new BookDetailsDALModel();
            BookDALModel.BookName = bookDetailsBLLModel.BookName;
            BookDALModel.BookAuthor = bookDetailsBLLModel.BookAuthor;
            BookDALModel.BookIsbn = bookDetailsBLLModel.BookIsbn;
            BookDALModel.BookEdition = bookDetailsBLLModel.BookEdition;
            BookDALModel.BookDescription = bookDetailsBLLModel.BookDescription;
            BookDALModel.BookImage = bookDetailsBLLModel.BookImage;
            BookDALModel.University = bookDetailsBLLModel.University;
            BookDALModel.CourseName = bookDetailsBLLModel.CourseName;
            BookDALModel.UnitName = bookDetailsBLLModel.UnitName;
            BookDALModel.BookPrice = bookDetailsBLLModel.BookPrice;
            try
            {
                _dataAccessService.AddBook(BookDALModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
