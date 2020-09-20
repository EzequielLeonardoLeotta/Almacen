using AutoMapper;
using Almacen.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Almacen.Services.WarehouseService;
using Almacen.Services.CategoryService;
using Almacen.Services.ProductService;
using Almacen.Services.CategorizationService;

namespace Almacen
{
  public class Startup
  {
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
      services.AddControllers();
      services.AddAutoMapper(typeof(Startup));
      services.AddScoped<IWarehouseService, WarehouseService>();
      services.AddScoped<ICategoryService, CategoryService>();
      services.AddScoped<IProductService, ProductService>();
      services.AddScoped<ICategorizationService, CategorizationService>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();
      app.UseAuthorization();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}