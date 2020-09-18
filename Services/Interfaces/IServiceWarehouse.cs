using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Services.Interfaces
{
  public interface IServiceWarehouse
  {
    #region CRUD
    Task<ServiceResponse<List<Warehouse>>> GetAll();
    Task<ServiceResponse<Warehouse>> Get(int id);
    Task<ServiceResponse<List<Warehouse>>> Add(WarehouseDto warehouseDto);
    Task<ServiceResponse<Warehouse>> Update(Warehouse warehouse);
    Task<ServiceResponse<List<Warehouse>>> Delete(int id);
    #endregion
  }
}