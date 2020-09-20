using Almacen.Data;
using Almacen.Dtos;
using Almacen.Models;
using Almacen.Models.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Almacen.Services.CategorizationService
{
  public class CategorizationService : ICategorizationService
  {
    private readonly DataContext _context;

    public CategorizationService(DataContext context)
    {
      _context = context;
    }

    public async Task<ServiceResponse<bool>> Add(CategorizationDto categorizationDto)
    {
      ServiceResponse<bool> serviceResponse = new ServiceResponse<bool>();

      try
      {
        Product product = await _context.Product.FirstOrDefaultAsync(p => p.Id == categorizationDto.ProductId);
        Category category = await _context.Category.FirstOrDefaultAsync(c => c.Id == categorizationDto.CategoryId);
        Categorization categorization = new Categorization
        {
          Product = product,
          Category = category
        };
        await _context.Categorization.AddAsync(categorization);
        await _context.SaveChangesAsync();
        serviceResponse.Data = true;
      }
      catch (Exception e)
      {
        serviceResponse.Data = false;
        serviceResponse.Success = false;
        serviceResponse.Message = e.Message;
      }

      return serviceResponse;
    }
  }
}