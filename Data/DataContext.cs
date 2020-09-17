using Almacen.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace Almacen.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<ExampleClass> ExampleClass { get; set; }
  }
}