namespace Almacen.Models.Classes
{
  public class Warehouse
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }

    public Warehouse(string name, string address)
    {
      Name = name;
      Address = address;
    }
  }
}