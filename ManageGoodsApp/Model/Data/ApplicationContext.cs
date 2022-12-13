using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ManageGoodsApp.Model.Data;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Supply> Supplies { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Audit> Audit { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ManageGoodsAppDb;Trusted_Connection=True");
    }

}