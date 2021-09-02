using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIA2.Models;

namespace WebAPIA2.Data
{
    public class WebAPIA2DBContext : DbContext
    {
        public WebAPIA2DBContext(DbContextOptions<WebAPIA2DBContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = WebAPIA2Database.sqlite");
        }
    }
}
