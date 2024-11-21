using Microsoft.EntityFrameworkCore;
using TheCollectorApp.Models;

// Testar DbContext i Entity Framework Core
// Presentation - Enity_Framework_intro

namespace TheCollectorApp.Data
{
    public class CollectorDbContext : DbContext
    {
        // DBset för alla klasser (objekt)
        public DbSet<User> Users { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionItem> CollectionItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Databasoppling
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // konfigration
        }

        // Konfigurerar relationer och regler
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Gör användarnamn unik
            modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

            // Gör e-post unik
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        }
    }
}
