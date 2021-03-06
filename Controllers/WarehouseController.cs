﻿using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using Almacen.Services.WarehouseService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class WarehouseController : ControllerBase
  {
    private readonly IWarehouseService _service;

    public WarehouseController(IWarehouseService service)
    {
      _service = service;
    }

    #region CRUD
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) => Ok(await _service.Get(id));

    [HttpPost]
    public async Task<IActionResult> Add(PostWarehouseDto warehouseDto) => Ok(await _service.Add(warehouseDto));

    [HttpPut]
    public async Task<IActionResult> Update(Warehouse warehouse)
    {
      ServiceResponse<Warehouse> response = await _service.Update(warehouse);
      return response.Data switch
      {
        null => NotFound(response),
        _ => Ok(response),
      };
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      ServiceResponse<List<GetWarehouseDto>> response = await _service.Delete(id);
      return response.Data switch
      {
        null => NotFound(response),
        _ => Ok(response),
      };
    }
    #endregion
  }
}