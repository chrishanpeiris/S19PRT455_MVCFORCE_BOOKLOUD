﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.DAL
{
    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Printer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
    }

    public class EfBridgeContext : DbContext
    {
        public EfBridgeContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Printer> Printer{ get; set; }
    }
}
