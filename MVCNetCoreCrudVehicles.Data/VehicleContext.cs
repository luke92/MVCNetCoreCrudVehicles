using Microsoft.EntityFrameworkCore;
using MVCNetCoreCrudVehicles.Data.Entities;

namespace MVCNetCoreCrudVehicles.Data
{
    public class VehicleContext : DbContext
    {       

        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles", "dbo");
            base.OnModelCreating(modelBuilder);
        }

        //entities
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
