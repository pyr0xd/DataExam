using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Entities;

namespace DataExam.DataBaseContext
{
    public class CandyStoreContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        // Add other DbSet properties for your entities

        public CandyStoreContext(DbContextOptions<CandyStoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Optionally, configure your model relationships using the Fluent API here
        }
    }
}
