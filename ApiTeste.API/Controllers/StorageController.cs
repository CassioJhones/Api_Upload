using ApiTeste.Application.UseCases.Users.UploadFoto;
using Microsoft.AspNetCore.Mvc;

namespace ApiTeste.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadImage(IFormFile arquivo)
    {

        UploadFotoUseCase usecase = new();

        usecase.Execute();

        return Created();
    }
}
