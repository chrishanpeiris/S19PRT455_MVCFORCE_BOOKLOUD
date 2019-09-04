using System;
using System.Collections.Generic;
using System.Text;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BOOKLOUD.Data
{
    public class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookEdition { get; set; }
        public string BookISBN { get; set; }
        public string UniversityLocation { get; set; }
        public string CourseName { get; set; }
        public string UnitName { get; set; }
        public string BookImage { get; set; }
        public int BookPrice { get; set; }
        public string BookDescription { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Book> Book { get; set; }
    }
}
