using System.Collections.Generic;

namespace Almacen.Models.Classes
{
  public class Category
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Product> Products { get; set; }
  }
}