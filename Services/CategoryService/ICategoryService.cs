using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Services.CategoryService
{
  public interface ICategoryService
  {
    #region CRUD
    Task<ServiceResponse<List<GetCategoryDto>>> GetAll();
    Task<ServiceResponse<GetCategoryDto>> Get(int id);
    Task<ServiceResponse<List<GetCategoryDto>>> Add(PostCategoryDto categoryDto);
    Task<ServiceResponse<Category>> Update(Category category);
    Task<ServiceResponse<List<GetCategoryDto>>> Delete(int id);
    #endregion
  }
}