//using AutoMapper;
//using Almacen.Data;
//using Almacen.Dtos;
//using Almacen.Models;
//using Almacen.Models.Classes;
//using Almacen.Services.Interfaces;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Almacen.Services.Implementations
//{
//  public class ServiceProduct : IServiceProduct
//  {
//    private readonly IMapper _mapper;
//    private readonly DataContext _context;

//    public ServiceProduct(IMapper mapper, DataContext context)
//    {
//      _mapper = mapper;
//      _context = context;
//    }

//    #region CRUD
//    public async Task<ServiceResponse<List<Product>>> GetAll()
//    {
//      ServiceResponse<List<Product>> serviceResponse = new ServiceResponse<List<Product>>();

//      try
//      {
//        serviceResponse.Data = await GetAllExampleClasses();
//      }
//      catch (Exception e)
//      {
//        serviceResponse.Success = false;
//        serviceResponse.Message = e.Message;
//      }

//      return serviceResponse;
//    }

//    public async Task<ServiceResponse<Product>> Get(int id)
//    {
//      ServiceResponse<Product> serviceResponse = new ServiceResponse<Product>();

//      try
//      {
//        serviceResponse.Data = await GetExampleClass(id);
//        return serviceResponse;
//      }
//      catch (Exception e)
//      {
//        serviceResponse.Success = false;
//        serviceResponse.Message = e.Message;
//      }

//      return serviceResponse;
//    }

//    public async Task<ServiceResponse<List<Product>>> Add(ProductDto dto)
//    {
//      ServiceResponse<List<Product>> serviceResponse = new ServiceResponse<List<Product>>();

//      try
//      {
//        await _context.Product.AddAsync(_mapper.Map<Product>(dto));
//        await _context.SaveChangesAsync();
//        serviceResponse.Data = await GetAllExampleClasses();
//      }
//      catch (Exception e)
//      {
//        serviceResponse.Success = false;
//        serviceResponse.Message = e.Message;
//      }

//      return serviceResponse;
//    }

//    public async Task<ServiceResponse<Product>> Update(Product exampleClass)
//    {
//      ServiceResponse<Product> serviceResponse = new ServiceResponse<Product>();

//      try
//      {
//        _context.Product.Update(exampleClass);
//        await _context.SaveChangesAsync();
//        serviceResponse.Data = exampleClass;
//      }
//      catch (Exception e)
//      {
//        serviceResponse.Success = false;
//        serviceResponse.Message = e.Message;
//      }

//      return serviceResponse;
//    }

//    public async Task<ServiceResponse<List<Product>>> Delete(int id)
//    {
//      ServiceResponse<List<Product>> serviceResponse = new ServiceResponse<List<Product>>();

//      try
//      {
//        Product exampleClass = await GetExampleClass(id);
//        _context.Product.Remove(exampleClass);
//        await _context.SaveChangesAsync();
//        serviceResponse.Data = await GetAllExampleClasses();
//      }
//      catch (Exception e)
//      {
//        serviceResponse.Success = false;
//        serviceResponse.Message = e.Message;
//      }

//      return serviceResponse;
//    }
//    #endregion

//    //Si tengo que incluir una clase relacionada utilizo Include
//    //await _context.ExampleClass.Include(p => p.Class).FirstOrDefaultAsync(c => c.Id == id);

//    private async Task<Product> GetExampleClass(int id) => await _context.Product.FirstOrDefaultAsync(c => c.Id == id);
//    private async Task<List<Product>> GetAllExampleClasses() => await _context.Product.ToListAsync();
//  }
//}