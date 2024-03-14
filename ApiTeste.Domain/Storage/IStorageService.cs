using ApiTeste.Domain.Entidades;
using Microsoft.AspNetCore.Http;

namespace ApiTeste.Domain.Storage;
public interface IStorageService
{
    string Upload(IFormFile arquivo, User user);
}
