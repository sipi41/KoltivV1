using KoltivV1.Models;
using Microsoft.EntityFrameworkCore;

namespace KoltivV1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>().HasData(
               new Setting { Id = 1, Name = "Map_Initial_LAT", Value = "35.4689" },
               new Setting { Id = 2, Name = "Map_Initial_LON", Value = "-97.5195" },
                new Setting { Id = 3, Name = "Map_Initial_ZOOM", Value = "5" }
            );

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Setting> Settings { get; set; }

    }
}
