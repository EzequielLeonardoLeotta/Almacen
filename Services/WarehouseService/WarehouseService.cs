using Almacen.Data;
using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Almacen.Services.WarehouseService
{
  public class WarehouseService : IWarehouseService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public WarehouseService(IMapper mapper, DataContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    #region CRUD
    public async Task<ServiceResponse<List<GetWarehouseDto>>> GetAll()
    {
      ServiceResponse<List<GetWarehouseDto>> serviceResponse = new ServiceResponse<List<GetWarehouseDto>>();

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

    public async Task<ServiceResponse<GetWarehouseDto>> Get(int id)
    {
      ServiceResponse<GetWarehouseDto> serviceResponse = new ServiceResponse<GetWarehouseDto>();

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

    public async Task<ServiceResponse<List<GetWarehouseDto>>> Add(PostWarehouseDto warehouseDto)
    {
      ServiceResponse<List<GetWarehouseDto>> serviceResponse = new ServiceResponse<List<GetWarehouseDto>>();

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

    public async Task<ServiceResponse<List<GetWarehouseDto>>> Delete(int id)
    {
      ServiceResponse<List<GetWarehouseDto>> serviceResponse = new ServiceResponse<List<GetWarehouseDto>>();

      try
      {
        Warehouse warehouse = _mapper.Map<Warehouse>(await GetWarehouse(id));
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

    private async Task<GetWarehouseDto> GetWarehouse(int id) 
    {
      var warehouse = _mapper.Map<GetWarehouseDto>(await _context.Warehouse.FirstOrDefaultAsync(c => c.Id == id));
      var productsByWarehouse = (await _context.Product.ToListAsync()).AsEnumerable().Where(p => p.Warehouse != null && p.Warehouse.Id == id).ToList();
      if (productsByWarehouse.Count > 0)
      {
        Dictionary<string, int> products = new Dictionary<string, int>();

        foreach (var product in productsByWarehouse)
        {
          string productName = product.Name;
          int quantity = 0;
          if (!products.ContainsKey(productName))
          {
            quantity = productsByWarehouse.Count(p => p.Name == productName);
            products.Add(productName, quantity);
          }
        }

        warehouse.Products = products;
      }
     
      return warehouse;
    }

    private async Task<List<GetWarehouseDto>> GetAllWarehouses() 
    {
      List<GetWarehouseDto> warehouses = _mapper.Map<List<GetWarehouseDto>>(await _context.Warehouse.ToListAsync());
      foreach (var warehouse in warehouses)
      {
        warehouse.Products = GetWarehouse(warehouse.Id).Result.Products;
      }

     return warehouses;
    } 
  }
}