using System;

namespace Almacen.Dtos
{
  public class PostProductDto
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int WarehouseId { get; set; }
    public DateTime ExpirationDate { get; set; }
  }
}