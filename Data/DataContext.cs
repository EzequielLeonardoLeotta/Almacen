using BE_Template_NetCore.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace BE_Template_NetCore.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<ExampleClass> ExampleClass { get; set; }
  }
}