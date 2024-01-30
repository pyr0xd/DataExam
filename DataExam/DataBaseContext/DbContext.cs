using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;

public class CandyStoreContext : DbContext
{
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<OrderDetailsEntity> OrderDetails { get; set; }
    public DbSet<CartEntity> Carts { get; set; }
    public DbSet<CartItemEntity> CartItems { get; set; }
  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\School02\DataExam\DataExam\Data\CandyDataBase.mdf;Integrated Security=True;Connect Timeout=30");
        }
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
    }
}
