using System.Collections.Generic;

namespace Almacen.Dtos
{
  public class GetCategoryDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ProductDto> Categorization { get; set; }
  }
}