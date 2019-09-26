using System;
using System.Collections.Generic;
using System.Text;
using BOOKLOUD.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BOOKLOUD.DataAccessLayer.DataContext
{
    public class BookCloudDbContext : DbContext
    {
        public BookCloudDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookDetailsDALModel> Book { get; set; }
        public DbSet<UniversityDetailsDALModel> University { get; set; }
        public DbSet<CourseDetailsDALModel> Course { get; set; }
        public DbSet<UnitDetailsDALModel> Unit { get; set; }
    }
}
