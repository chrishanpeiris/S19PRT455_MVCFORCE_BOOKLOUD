﻿using System.ComponentModel.DataAnnotations;

namespace BOOKLOUD.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Book Name length can't be more than 25 letters.")]
        public string BookName { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Author Name length can't be more than 25 letters.")]
        public string BookAuthor { get; set; }
        public string BookEdition { get; set; }
        public string BookIsbn { get; set; }
        public string UniversityLocation { get; set; }
        public string CourseName { get; set; }
        public string UnitName { get; set; }
        public string BookImage { get; set; }
        [Required]
        [Range(0, 9999, ErrorMessage = "Book Price should be a number")]
        public int BookPrice { get; set; } = 1;
        public string BookDescription { get; set; }
    }
}