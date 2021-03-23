using System.Threading.Tasks;
using Srt.Authentication.Models;

namespace Srt.Authentication.Application
{
    public interface IUsersService
    {
        Task<SrtUser> GetUser(SrtUserCredentials credentials);
    }
}