using AutoMapper;
using BE_Template_NetCore.Data;
using BE_Template_NetCore.Dtos;
using BE_Template_NetCore.Models;
using BE_Template_NetCore.Models.Classes;
using BE_Template_NetCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_Template_NetCore.Services.Implementations
{
  public class Service : IService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public Service(IMapper mapper, DataContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    #region CRUD
    public async Task<ServiceResponse<List<ExampleClass>>> GetAll()
    {
      ServiceResponse<List<ExampleClass>> serviceResponse = new ServiceResponse<List<ExampleClass>>();

      try
      {
        serviceResponse.Data = await GetAllExampleClasses();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<ExampleClass>> Get(int id)
    {
      ServiceResponse<ExampleClass> serviceResponse = new ServiceResponse<ExampleClass>();

      try
      {
        serviceResponse.Data = await GetExampleClass(id);
        return serviceResponse;
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<ExampleClass>>> Add(Dto dto)
    {
      ServiceResponse<List<ExampleClass>> serviceResponse = new ServiceResponse<List<ExampleClass>>();

      try
      {
        await _context.ExampleClass.AddAsync(_mapper.Map<ExampleClass>(dto));
        await _context.SaveChangesAsync();
        serviceResponse.Data = await GetAllExampleClasses();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<ExampleClass>> Update(ExampleClass exampleClass)
    {
      ServiceResponse<ExampleClass> serviceResponse = new ServiceResponse<ExampleClass>();

      try
      {
        _context.ExampleClass.Update(exampleClass);
        await _context.SaveChangesAsync();
        serviceResponse.Data = exampleClass;
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<ExampleClass>>> Delete(int id)
    {
      ServiceResponse<List<ExampleClass>> serviceResponse = new ServiceResponse<List<ExampleClass>>();

      try
      {
        ExampleClass exampleClass = await GetExampleClass(id);
        _context.ExampleClass.Remove(exampleClass);
        await _context.SaveChangesAsync();
        serviceResponse.Data = await GetAllExampleClasses();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }
    #endregion

    //Si tengo que incluir una clase relacionada utilizo Include
    //await _context.ExampleClass.Include(p => p.Class).FirstOrDefaultAsync(c => c.Id == id);

    private async Task<ExampleClass> GetExampleClass(int id) => await _context.ExampleClass.FirstOrDefaultAsync(c => c.Id == id);
    private async Task<List<ExampleClass>> GetAllExampleClasses() => await _context.ExampleClass.ToListAsync();
  }
}