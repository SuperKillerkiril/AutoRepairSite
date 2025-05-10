using Microsoft.EntityFrameworkCore;
using Model;
    
namespace Practical.DataBase;

public class ModelContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=PracticalDataBase.db");
    }
}