using ApiNetCore.Domain.Dtos;
using System.Threading.Tasks;

namespace ApiNetCore.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
        Task<object> FindByLogin(LoginDto user);
    }
}
