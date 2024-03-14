using FileTypeChecker;
using Microsoft.AspNetCore.Http;

namespace ApiTeste.Application.UseCases.Users.UploadFoto;
public class UploadFotoUseCase
{

    public void Execute(IFormFile arquivo)
    {
        Stream sLeitor = arquivo.OpenReadStream();
        bool ehImagem = FileTypeValidator.IsImage(sLeitor);

    }
}
