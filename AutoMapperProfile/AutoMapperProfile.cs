using AutoMapper;
using BE_Template_NetCore.Dtos;
using BE_Template_NetCore.Models.Classes;

namespace BE_Template_NetCore.AutoMapperProfile
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<Dto, ExampleClass>();
    }
  }
}