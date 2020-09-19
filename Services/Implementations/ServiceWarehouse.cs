using Almacen.Data;
using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using Almacen.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Services.Implementations
{
  public class ServiceWarehouse : IServiceWarehouse
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public ServiceWarehouse(IMapper mapper, DataContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    #region CRUD
    public async Task<ServiceResponse<List<Warehouse>>> GetAll()
    {
      ServiceResponse<List<Warehouse>> serviceResponse = new ServiceResponse<List<Warehouse>>();

      try
      {
        serviceResponse.Data = await GetAllWarehouses();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<Warehouse>> Get(int id)
    {
      ServiceResponse<Warehouse> serviceResponse = new ServiceResponse<Warehouse>();

      try
      {
        serviceResponse.Data = await GetWarehouse(id);
        return serviceResponse;
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<Warehouse>>> Add(WarehouseDto warehouseDto)
    {
      ServiceResponse<List<Warehouse>> serviceResponse = new ServiceResponse<List<Warehouse>>();

      try
      {
        await _context.Warehouse.AddAsync(_mapper.Map<Warehouse>(warehouseDto));
        await _context.SaveChangesAsync();
        serviceResponse.Data = await GetAllWarehouses();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<Warehouse>> Update(Warehouse warehouse)
    {
      ServiceResponse<Warehouse> serviceResponse = new ServiceResponse<Warehouse>();

      try
      {
        _context.Warehouse.Update(warehouse);
        await _context.SaveChangesAsync();
        serviceResponse.Data = warehouse;
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<Warehouse>>> Delete(int id)
    {
      ServiceResponse<List<Warehouse>> serviceResponse = new ServiceResponse<List<Warehouse>>();

      try
      {
        Warehouse warehouse = await GetWarehouse(id);
        _context.Warehouse.Remove(warehouse);
        await _context.SaveChangesAsync();
        serviceResponse.Data = await GetAllWarehouses();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }
    #endregion
    
    private async Task<Warehouse> GetWarehouse(int id) => await _context.Warehouse.FirstOrDefaultAsync(c => c.Id == id);
    private async Task<List<Warehouse>> GetAllWarehouses() => await _context.Warehouse.ToListAsync();
  }
}