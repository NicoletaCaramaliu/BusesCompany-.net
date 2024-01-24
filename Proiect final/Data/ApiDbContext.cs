using Microsoft.EntityFrameworkCore;
using Proiect_final.Models.Bus;
using Proiect_final.Models.Driver;


namespace Proiect_final.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>().ToTable("Bus");
            //number is unique
            modelBuilder.Entity<Bus>()
                .HasIndex(b => b.Number)
                .IsUnique();

            // one to many relationship between bus and driver a bus can have many drivers
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Bus)
                .WithMany(b => b.Drivers)
                .HasForeignKey(d => d.BusId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
