using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                Settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                opsBuilder.UseSqlServer(Settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> opsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> dbOptions { get; set;}
            private AppConfiguration Settings { get; set; }


        }
        public static OptionsBuild ops = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
    }
}
