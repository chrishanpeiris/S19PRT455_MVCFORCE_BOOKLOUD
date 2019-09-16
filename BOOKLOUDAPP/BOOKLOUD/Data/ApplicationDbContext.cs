using System;
using System.Collections.Generic;
using System.Text;
using BOOKLOUD.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BOOKLOUD.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Book> Book { get; set; }
        public DbSet<UniversityDetailsModel> University { get; set; }
        public DbSet<CourseDetailsModel> Course { get; set; }
        public DbSet<UnitDetailsModel> Unit { get; set; }
    }
}
