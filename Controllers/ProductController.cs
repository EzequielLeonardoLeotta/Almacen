using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using Almacen.Services.ProductService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class ProductController : ControllerBase
  {
    private readonly IProductService _service;

    public ProductController(IProductService service)
    {
      _service = service;
    }

    #region CRUD
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _service.Get(id));

    [HttpPost]
    public async Task<IActionResult> Add(PostProductDto productDto) => Ok(await _service.Add(productDto));

    [HttpPut]
    public async Task<IActionResult> Update(PutProductDto putProductDto)
    {
      ServiceResponse<Product> response = await _service.Update(putProductDto);
      return response.Data switch
      {
        null => NotFound(response),
        _ => Ok(response),
      };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      ServiceResponse<List<GetProductDto>> response = await _service.Delete(id);
      return response.Data switch
      {
        null => NotFound(response),
        _ => Ok(response),
      };
    }
    #endregion
  }
}