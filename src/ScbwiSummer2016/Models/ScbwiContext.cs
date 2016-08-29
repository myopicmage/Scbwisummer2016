using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScbwiSummer2016.Models
{
    public class ScbwiContext : DbContext
    {
        public DbSet<Location> locations { get; set; }
        public DbSet<Registration> registrations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./scbwi.db");
        }
    }
}
