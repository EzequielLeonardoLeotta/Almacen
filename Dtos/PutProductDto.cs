namespace Almacen.Dtos
{
  public class PutProductDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int WarehouseId { get; set; }
  }
}