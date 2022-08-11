using Api.Core.DTOs;
using Api.Core.Models.Responses;

namespace Api.Core.Interfaces
{
    public interface IServiceAuth
    {
        Task<LoginResponse> Login(string username, string password);
        string CreateToken(Usuario usuario);
    }
}
