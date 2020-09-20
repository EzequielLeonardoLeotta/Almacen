using Almacen.Dtos;
using Almacen.Services.CategorizationService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Almacen.Controllers
{
  [ApiController]
  [Route("api/v1/[controller]")]
  public class CategorizationController : ControllerBase
  {
    private readonly ICategorizationService _service;

    public CategorizationController(ICategorizationService service)
    {
      _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Add(CategorizationDto categorizationDto) => Ok(await _service.Add(categorizationDto));
  }
}