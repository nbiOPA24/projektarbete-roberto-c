using Microsoft.EntityFrameworkCore;
using TheCollectorApp.Models;

// Testar DbContext i Entity Framework Core
//https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/#readme-body-tab
// https://www.connectionstrings.com/sql-server/
// Presentation - Enity_Framework_intro

namespace TheCollectorApp.Data
{
    public class CollectorDbContext : DbContext
    {
        // Varje DBset representerar en tabell i databasen
        public DbSet<User> Users { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionItem> CollectionItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Databasoppling
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=CollectorDb;Trusted_Connection=True;TrustServerCertificate=True;"
            );
        }

        // Konfigurerar relationer och regler
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Regler 

            // konverterar enum till string
            modelBuilder.Entity<Collection>()
            .Property(e => e.Type)
            .HasConversion<string>();

            modelBuilder.Entity<CollectionItem>()
            .Property(e => e.Condition)
            .HasConversion<string>();

            modelBuilder.Entity<Category>()
            .Property(c => c.Type)
            .HasConversion<string>();

            // Gör användarnamn unik
            modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();

            // Gör e-post unik
            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

            // Relationer mellan klasserna
            //https://learn.microsoft.com/en-us/ef/core/modeling/relationships

            modelBuilder.Entity<User>()
            // En användare har många samlingar
            .HasMany(u => u.Collections)
            // En samlingar har bara en användare
            .WithOne(c => c.Owner)
            // Nyckel kopplat till ID
            .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<Collection>()
            // En samlingar har många samlingsobjekt
            .HasMany(c => c.Items)
            // Ett samlingobjekt har bara en samling 
            .WithOne(i => i.Collection)
            // Nyckel kopplat till ID
            .HasForeignKey(i => i.CollectionId);

            modelBuilder.Entity<CollectionItem>()
            // Ett samlingsobjekt har många kategorier
            .HasMany(i => i.Categories)
            // En kategiri har många samlingsobjekt
            .WithMany(c => c.Items);
        }
    }
}
