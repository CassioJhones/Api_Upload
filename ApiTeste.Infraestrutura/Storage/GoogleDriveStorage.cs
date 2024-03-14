using ApiTeste.Domain.Entidades;
using ApiTeste.Domain.Storage;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;

namespace ApiTeste.Infraestrutura.Storage;
public class GoogleDriveStorage : IStorageService
{
    public string Upload(IFormFile arquivo, User user)
    {
        DriveService servicoGoogle = new();

        Google.Apis.Drive.v3.Data.File arquivoDrive = new()
        {
            Name = arquivo.Name,
            MimeType = arquivo.ContentType
        };
        FilesResource.CreateMediaUpload comando = servicoGoogle.Files.Create(arquivoDrive, arquivo.OpenReadStream(), arquivo.ContentType);

        Google.Apis.Upload.IUploadProgress resultado = comando.Upload();

        if (resultado.Status is not Google.Apis.Upload.UploadStatus.Completed
            or Google.Apis.Upload.UploadStatus.NotStarted)
            throw resultado.Exception;
    }
}
