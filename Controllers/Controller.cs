using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using Almacen.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class Controller : ControllerBase
  {
    private readonly IService _service;

    public Controller(IService service)
    {
      _service = service;
    }

    #region CRUD
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _service.Get(id));

    [HttpPost]
    public async Task<IActionResult> Add(Dto dto) => Ok(await _service.Add(dto));

    [HttpPut]
    public async Task<IActionResult> Update(ExampleClass exampleClass)
    {
      ServiceResponse<ExampleClass> response = await _service.Update(exampleClass);
      return response.Data switch
      {
        null => NotFound(response),
        _ => Ok(response),
      };
    }

    [HttpDelete("attribute/{attribute}")]
    public async Task<IActionResult> Delete(int id)
    {
      ServiceResponse<List<ExampleClass>> response = await _service.Delete(id);
      return response.Data switch
      {
        null => NotFound(response),
        _ => Ok(response),
      };
    }
    #endregion
  }
}