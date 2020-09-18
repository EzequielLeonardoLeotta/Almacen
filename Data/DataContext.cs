using Almacen.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Product> Product { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Warehouse> Warehouse { get; set; }
  }
}