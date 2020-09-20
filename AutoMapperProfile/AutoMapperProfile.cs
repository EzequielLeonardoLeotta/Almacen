using AutoMapper;
using Almacen.Dtos;
using Almacen.Models.Classes;
using System.Linq;

namespace Almacen.AutoMapperProfile
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      #region Warehouse
      CreateMap<PostWarehouseDto, Warehouse>();
      CreateMap<GetWarehouseDto, Warehouse>();
      CreateMap<Warehouse, GetWarehouseDto>();
      #endregion

      #region Product
      CreateMap<PostProductDto, Product>();
      CreateMap<Product, ProductDto>();
      CreateMap<GetProductDto, Product>();
      CreateMap<PutProductDto, Product>();
      CreateMap<Product, GetProductDto>()
        .ForMember(dto => dto.Categorization, c => c.MapFrom(c => c.Categorizations.Select(ca => ca.Category)));
      #endregion

      #region Category
      CreateMap<PostCategoryDto, Category>();
      CreateMap<Category, CategoryDto>();
      CreateMap<GetCategoryDto, Category>();
      CreateMap<Category, GetCategoryDto>()
        .ForMember(dto => dto.Categorization, c => c.MapFrom(c => c.Categorizations.Select(ca => ca.Product)));
      #endregion
    }
  }
}