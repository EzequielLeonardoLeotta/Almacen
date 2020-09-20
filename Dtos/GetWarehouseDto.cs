using System.Collections.Generic;

namespace Almacen.Dtos
{
  public class GetWarehouseDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Dictionary<string, int> Products { get; set; }
  }
}