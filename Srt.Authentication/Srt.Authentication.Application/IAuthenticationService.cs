using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Srt.Authentication.Models;

namespace Srt.Authentication.Application
{
    public interface IAuthenticationService
    {
        public Task<SrtToken> AuthenticateUser(SrtUserCredentials credentials);
    }
}
