using Almacen.Data;
using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Almacen.Services.CategoryService
{
  public class CategoryService : ICategoryService
  {
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public CategoryService(IMapper mapper, DataContext context)
    {
      _mapper = mapper;
      _context = context;
    }

    #region CRUD
    public async Task<ServiceResponse<List<GetCategoryDto>>> GetAll()
    {
      ServiceResponse<List<GetCategoryDto>> serviceResponse = new ServiceResponse<List<GetCategoryDto>>();

      try
      {
        serviceResponse.Data = await GetAllCategories();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCategoryDto>> Get(int id)
    {
      ServiceResponse<GetCategoryDto> serviceResponse = new ServiceResponse<GetCategoryDto>();

      try
      {
        serviceResponse.Data = await GetCategory(id);
        return serviceResponse;
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCategoryDto>>> Add(PostCategoryDto categoryDto)
    {
      ServiceResponse<List<GetCategoryDto>> serviceResponse = new ServiceResponse<List<GetCategoryDto>>();

      try
      {
        await _context.Category.AddAsync(_mapper.Map<Category>(categoryDto));
        await _context.SaveChangesAsync();
        serviceResponse.Data = await GetAllCategories();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<Category>> Update(Category category)
    {
      ServiceResponse<Category> serviceResponse = new ServiceResponse<Category>();

      try
      {
        _context.Category.Update(category);
        await _context.SaveChangesAsync();
        serviceResponse.Data = category;
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCategoryDto>>> Delete(int id)
    {
      ServiceResponse<List<GetCategoryDto>> serviceResponse = new ServiceResponse<List<GetCategoryDto>>();

      try
      {
        Category category = _mapper.Map<Category>(await GetCategory(id));
        _context.Category.Remove(category);
        await _context.SaveChangesAsync();
        serviceResponse.Data = await GetAllCategories();
      }
      catch (Exception e)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }
    #endregion

    private async Task<GetCategoryDto> GetCategory(int id) => _mapper.Map<GetCategoryDto>(await _context.Category.AsNoTracking().Include(c => c.Categorizations).ThenInclude(ca => ca.Product).FirstOrDefaultAsync(c => c.Id == id));
    private async Task<List<GetCategoryDto>> GetAllCategories() => _mapper.Map<List<GetCategoryDto>>(await _context.Category.Include(c => c.Categorizations).ThenInclude(ca => ca.Product).ToListAsync());
  }
}