using Microsoft.EntityFrameworkCore;
using Zaap.Models;

namespace Zaap.Persistence
{
    public class ZaapDbContext : DbContext
    {
        public ZaapDbContext(DbContextOptions<ZaapDbContext> options)
            : base(options)
        {

        }



        public DbSet<Make> Makes { get; set; }
        public DbSet<Feauture> Feautures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
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

        }

    }
}