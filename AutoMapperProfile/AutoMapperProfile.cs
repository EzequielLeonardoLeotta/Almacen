using AutoMapper;
using Almacen.Dtos;
using Almacen.Models.Classes;

namespace Almacen.AutoMapperProfile
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Dto, ExampleClass>();
    }
  }
}