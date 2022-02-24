using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCollection.Model
{
    /// <summary>
    /// Entity Framework Core DbContext class
    /// </summary>
    public class LibraryDbContext : DbContext
    {
        public DbSet<Image> Images { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Company> Companies { get; set; }

        private string dbLocation;
        public LibraryDbContext(string filePath)
        {
            dbLocation = filePath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
               $"Data Source={dbLocation}"); // DB is a SQLite db
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }
        
        
    }
}
