using DeviconBack.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeviconBack.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Valute> Valutes { get; set; }
        public DbSet<ValuteCourse> ValuteCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Valute>()
                .HasOne(x => x.ValuteCourse)
                .WithMany(x => x.Valutes)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
