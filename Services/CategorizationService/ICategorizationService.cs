using Almacen.Dtos;
using Almacen.Models;
using System.Threading.Tasks;

namespace Almacen.Services.CategorizationService
{
  public interface ICategorizationService
  {
    Task<ServiceResponse<bool>> Add(CategorizationDto categorizationDto);
  }
}