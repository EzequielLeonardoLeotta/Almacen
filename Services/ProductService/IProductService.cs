using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Services.ProductService
{
  public interface IProductService
  {
    #region CRUD
    Task<ServiceResponse<List<GetProductDto>>> GetAll();
    Task<ServiceResponse<GetProductDto>> Get(int id);
    Task<ServiceResponse<List<GetProductDto>>> Add(PostProductDto dto);
    Task<ServiceResponse<Product>> Update(PutProductDto putProductDto);
    Task<ServiceResponse<List<GetProductDto>>> Delete(int id);
    #endregion
  }
}