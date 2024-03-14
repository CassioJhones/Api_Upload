using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadImage(IFormFile arquivo)
    {
        return Created();
    }
}
