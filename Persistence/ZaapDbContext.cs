using Microsoft.EntityFrameworkCore;
using Zaap.Models;

namespace Zaap.Persistence
{
    public class ZaapDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<Feauture> Feautures { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public ZaapDbContext(DbContextOptions<ZaapDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<VehicleFeature>()
            .ToTable("VehicleFeatures")
            .HasKey(vf => new { vf.VehicleId, vf.FeatureId });


            modelbuilder.Entity<Make>()
            .Property(t => t.Name)
            .HasMaxLength(255)
            .IsRequired();

            modelbuilder.Entity<Model>()
            .Property(m => m.Name)
            .HasMaxLength(255)
            .IsRequired();

            modelbuilder.Entity<Model>()
            .ToTable("Models");

            modelbuilder.Entity<Feauture>()
            .Property(f => f.Name)
            .HasMaxLength(255)
            .IsRequired();

            modelbuilder.Entity<Vehicle>()
            .Property(v => v.ContactName)
            .HasMaxLength(255)
            .IsRequired();

            modelbuilder.Entity<Vehicle>()
                        .Property(v => v.ContactPhone)
                        .HasMaxLength(255)
                        .IsRequired();
            modelbuilder.Entity<Vehicle>()
                      .Property(v => v.ContactEmail)
                      .HasMaxLength(255);
        }

    }
}