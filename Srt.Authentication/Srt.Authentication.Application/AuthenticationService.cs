using System;
using System.Threading.Tasks;
using Srt.Authentication.Models;

namespace Srt.Authentication.Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUsersService _usersService;

        public AuthenticationService(IUsersService usersService)
        {
            _usersService = usersService;
        }
        public async Task<SrtToken> AuthenticateUser(SrtUserCredentials credentials)
        {
            SrtUser srtUser = await _usersService.GetUser(credentials);
            if (srtUser is null)
            {
                return null;
            }
            return srtUser.Password == credentials.Password ? new SrtToken(){ Expiry = DateTime.Now.AddDays(1), Token = TokenUtility.GetToken(credentials.UserName)} : null;
        }
    }
}
