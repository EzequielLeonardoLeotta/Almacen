using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Services.Interfaces
{
  public interface IService
  {
    #region CRUD
    Task<ServiceResponse<List<Product>>> GetAll();
    Task<ServiceResponse<Product>> Get(int id);
    Task<ServiceResponse<List<Product>>> Add(Dto dto);
    Task<ServiceResponse<Product>> Update(Product exampleClass);
    Task<ServiceResponse<List<Product>>> Delete(int id);
    #endregion
  }
}