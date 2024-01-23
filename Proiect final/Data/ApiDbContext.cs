using Microsoft.EntityFrameworkCore;
using Proiect_final.Models.Bus;


namespace Proiect_final.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Bus> Buses { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>().ToTable("Bus");
            base.OnModelCreating(modelBuilder);
        }


    }
}
