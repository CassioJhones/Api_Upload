using ApiTeste.Domain.Entidades;
using ApiTeste.Domain.Storage;
using FileTypeChecker;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace ApiTeste.Application.UseCases.Users.UploadFoto;
public class UploadFotoUseCase
{
    private readonly IStorageService _storageService;

    public UploadFotoUseCase(IStorageService storageService) => _storageService = storageService;

    public void Execute(IFormFile arquivo)
    {
        Stream sLeitor = arquivo.OpenReadStream();
        bool ehImagem = FileTypeValidator.IsImage(sLeitor);

        bool fotoJPG = sLeitor.Is<JointPhotographicExpertsGroup>();

        if (ehImagem is false)
            throw new Exception("O Arquivo não é uma imagem!");

        User usuario = GetfromDataBase();
        _storageService.Upload(arquivo, usuario);
    }

    private User GetfromDataBase() => new()
    {
        id = 1,
        Nome = "Cassio",
        Email = "cassio.bjhones@gmail.com"
    };
}
