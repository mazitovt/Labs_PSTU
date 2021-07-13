using System.Linq;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace FacultyISBackend.EntityFrameworkController
{
    public class FacultyContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnectionHelper.GetConnectionString("MySQL"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Year).IsRequired();
            });
        }

        public void DiscardChanges()
        {
            ChangeTracker.Entries()
                .Where(e =>  e.Entity != null)
                .ToList()
                .ForEach(e => e.State = EntityState.Unchanged);
        }
    }
}