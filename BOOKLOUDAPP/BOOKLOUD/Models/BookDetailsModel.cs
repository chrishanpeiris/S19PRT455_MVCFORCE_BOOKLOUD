using System.ComponentModel.DataAnnotations;

namespace BOOKLOUD.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Book Name length can't be more than 50 letters.")]
        public string BookName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Author Name length can't be more than 50 letters.")]
        public string BookAuthor { get; set; }
        public string BookEdition { get; set; }
        public string BookIsbn { get; set; }
        public string UniversityLocation { get; set; }
        public string CourseName { get; set; }
        public string UnitName { get; set; }
        public string BookImage { get; set; }
        [Required]
        [Range(0, 9999, ErrorMessage = "Book Price should be a number and under 10000")]
        public int BookPrice { get; set; } = 1;
        public string BookDescription { get; set; }
        public string UserId { get; set; }
    }
}