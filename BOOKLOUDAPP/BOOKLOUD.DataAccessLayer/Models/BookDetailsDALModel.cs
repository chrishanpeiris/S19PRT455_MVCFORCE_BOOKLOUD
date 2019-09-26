using System;
using System.Collections.Generic;
using System.Text;

namespace BOOKLOUD.DataAccessLayer.Models
{
    public class BookDetailsDALModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookEdition { get; set; }
        public string BookIsbn { get; set; }
        public string University { get; set; }
        public string CourseName { get; set; }
        public string UnitName { get; set; }
        public string BookImage { get; set; }
        public int BookPrice { get; set; }
        public string BookDescription { get; set; }
    }

}
