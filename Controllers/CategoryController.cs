using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using Almacen.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class CategoryController : ControllerBase
  {
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
      _service = service;
    }

    #region CRUD
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _service.Get(id));

    [HttpPost]
    public async Task<IActionResult> Add(PostCategoryDto categoryDto) => Ok(await _service.Add(categoryDto));

    [HttpPut]
    public async Task<IActionResult> Update(Category category)
    {
      ServiceResponse<Category> response = await _service.Update(category);
      return response.Data switch
      {
        null => NotFound(response),
        _ => Ok(response),
      };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      ServiceResponse<List<GetCategoryDto>> response = await _service.Delete(id);
      return response.Data switch
      {
        null => NotFound(response),
        _ => Ok(response),
      };
    }
    #endregion
  }
}