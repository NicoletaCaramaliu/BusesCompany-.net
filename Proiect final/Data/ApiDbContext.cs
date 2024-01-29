using Microsoft.EntityFrameworkCore;
using Proiect_final.Models.Adress;
using Proiect_final.Models.Bus;
using Proiect_final.Models.Defection;
using Proiect_final.Models.Driver;
using Proiect_final.Models.RepairHistory;


namespace Proiect_final.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Defection> Defections { get; set; }
        public DbSet<RepairHistory> RepairHistories { get; set; }



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

            //one to one relationship between driver and adress
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Adress)
                .WithOne(d => d.Driver)
                .HasForeignKey<Adress>(a => a.DriverId);

            //many to many relationship between bus and defection, association table is RepairHistory
            modelBuilder.Entity<RepairHistory>()
                .HasKey(r => new {r.BusId, r.DefectionId});
            modelBuilder.Entity<RepairHistory>()
                .HasOne(r => r.Bus)
                .WithMany(b => b.RepairHistories)
                .HasForeignKey(r => r.BusId);
            modelBuilder.Entity<RepairHistory>()
                .HasOne(r => r.Defection)
                .WithMany(d => d.RepairHistories)
                .HasForeignKey(r => r.DefectionId);


            base.OnModelCreating(modelBuilder);
        }


    }
}
