using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public class DrivingDbContext: DbContext
    {
        public DrivingDbContext(DbContextOptions<DrivingDbContext> options) : base(options)
        {
        }

        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>().ToTable("drivers");
            modelBuilder.Entity<Car>().ToTable("cars");
        }
    }
}
