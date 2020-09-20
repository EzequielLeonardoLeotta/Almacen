using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Services.WarehouseService
{
  public interface IWarehouseService
  {
    #region CRUD
    Task<ServiceResponse<List<GetWarehouseDto>>> GetAll();
    Task<ServiceResponse<GetWarehouseDto>> Get(int id);
    Task<ServiceResponse<List<GetWarehouseDto>>> Add(PostWarehouseDto warehouseDto);
    Task<ServiceResponse<Warehouse>> Update(Warehouse warehouse);
    Task<ServiceResponse<List<GetWarehouseDto>>> Delete(int id);
    #endregion
  }
}