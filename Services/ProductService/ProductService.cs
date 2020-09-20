using AutoMapper;
using Almacen.Data;
using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Almacen.Services.ProductService
{
  public class ProductService : IProductService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IMapper mapper, DataContext context, ILogger<ProductService> logger)
    {
      _mapper = mapper;
      _context = context;
      _logger = logger;
    }

    #region CRUD
    public async Task<ServiceResponse<List<GetProductDto>>> GetAll()
    {
      ServiceResponse<List<GetProductDto>> serviceResponse = new ServiceResponse<List<GetProductDto>>();

      try
      {
        _logger.LogInformation("GetAllProducts");
        serviceResponse.Data = await GetAllProducts();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
        _logger.LogError(e.Message);
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<GetProductDto>> Get(int id)
    {
      ServiceResponse<GetProductDto> serviceResponse = new ServiceResponse<GetProductDto>();

      try
      {
        _logger.LogInformation("GetProduct");
        serviceResponse.Data = await GetProduct(id);
        return serviceResponse;
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
        _logger.LogError(e.Message);
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetProductDto>>> Add(PostProductDto productDto)
    {
      ServiceResponse<List<GetProductDto>> serviceResponse = new ServiceResponse<List<GetProductDto>>();

      try
      {
        _logger.LogInformation("AddProduct");
        Product product = _mapper.Map<Product>(productDto);
        product.AdmissionDate = DateTime.Now;
        product.Warehouse = await _context.Warehouse.FirstOrDefaultAsync(w => w.Id == productDto.WarehouseId);
        await _context.Product.AddAsync(product);
        await _context.SaveChangesAsync();
        serviceResponse.Data = await GetAllProducts();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
        _logger.LogError(e.Message);
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<Product>> Update(PutProductDto putProductDto)
    {
      ServiceResponse<Product> serviceResponse = new ServiceResponse<Product>();

      try
      {
        _logger.LogInformation("UpdateProduct");
        Product product = _mapper.Map<Product>(await GetProduct(putProductDto.Id));
        product.UpdateDate = DateTime.Now;
        product.Price = putProductDto.Price;
        product.Warehouse = await _context.Warehouse.FirstOrDefaultAsync(w => w.Id == putProductDto.WarehouseId);
        _context.Product.Update(product);
        await _context.SaveChangesAsync();
        serviceResponse.Data = product;
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
        _logger.LogError(e.Message);
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetProductDto>>> Delete(int id)
    {
      ServiceResponse<List<GetProductDto>> serviceResponse = new ServiceResponse<List<GetProductDto>>();

      try
      {
        _logger.LogInformation("DeleteProduct");
        Product product = _mapper.Map<Product>(await GetProduct(id));
        _context.Product.Remove(product);
        await _context.SaveChangesAsync();
        serviceResponse.Data = await GetAllProducts();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
        _logger.LogError(e.Message);
      }

      return serviceResponse;
    }
    #endregion

    private async Task<GetProductDto> GetProduct(int id) => _mapper.Map<GetProductDto>(await _context.Product.AsNoTracking().Include(p => p.Warehouse).Include(p => p.Categorizations).ThenInclude(ca => ca.Category).FirstOrDefaultAsync(p => p.Id == id));
    private async Task<List<GetProductDto>> GetAllProducts() => _mapper.Map<List<GetProductDto>>(await _context.Product.Include(p => p.Warehouse).Include(p => p.Categorizations).ThenInclude(ca => ca.Category).ToListAsync());
  }
}