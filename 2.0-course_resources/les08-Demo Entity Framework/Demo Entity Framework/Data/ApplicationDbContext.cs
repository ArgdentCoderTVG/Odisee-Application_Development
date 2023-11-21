using Demo_Entity_Framework.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demo_Entity_Framework.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BlogDatabase;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>().HasData(
                new Post() { Id = 1, Titel = "Mijn eerste bericht", Inhoud = "De inhoud van mijn bericht", PublicatieDatum = DateTime.Now },
                new Post() { Id = 2, Titel = "Mijn tweede bericht", Inhoud = "De inhoud van het andere bericht", PublicatieDatum = new DateTime(2022, 12, 1) }
            );
        }

        public DbSet<Post> Posts { get; set; }

    }
}
