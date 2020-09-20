using Almacen.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Warehouse> Warehouse { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Categorization> Categorization { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Categorization>()
          .HasKey(c => new { c.CategoryId, c.ProductId });
    }
  }
}