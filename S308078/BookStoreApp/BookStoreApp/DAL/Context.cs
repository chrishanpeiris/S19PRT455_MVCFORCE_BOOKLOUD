using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.DAL

{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Printer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
    public class Scannerr
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
    }
    public class EfBridgeContext : DbContext
    {
        public EfBridgeContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Printer> Printer { get; set; }
        public virtual DbSet<Scannerr> Scannerr { get; set; }
    }

}
