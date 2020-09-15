using BE_Template_NetCore.Dtos;
using BE_Template_NetCore.Models;
using BE_Template_NetCore.Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_Template_NetCore.Services.Interfaces
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