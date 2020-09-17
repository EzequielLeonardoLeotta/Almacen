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
    Task<ServiceResponse<List<ExampleClass>>> GetAll();
    Task<ServiceResponse<ExampleClass>> Get(int id);
    Task<ServiceResponse<List<ExampleClass>>> Add(Dto dto);
    Task<ServiceResponse<ExampleClass>> Update(ExampleClass exampleClass);
    Task<ServiceResponse<List<ExampleClass>>> Delete(int id);
    #endregion
  }
}