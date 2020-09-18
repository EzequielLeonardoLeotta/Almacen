using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Services.Interfaces
{
  public interface IServiceCategory
  {
    #region CRUD
    Task<ServiceResponse<List<Category>>> GetAll();
    Task<ServiceResponse<Category>> Get(int id);
    Task<ServiceResponse<List<Category>>> Add(ProductDto dto);
    Task<ServiceResponse<Category>> Update(Category category);
    Task<ServiceResponse<List<Category>>> Delete(int id);
    #endregion
  }
}