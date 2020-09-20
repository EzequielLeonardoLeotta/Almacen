using System;
using System.Collections.Generic;

namespace Almacen.Models.Classes
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public List<Categorization> Categorizations { get; set; }
    public Warehouse Warehouse { get; set; }
    public DateTime AdmissionDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public DateTime ExpirationDate { get; set; }
  }
}