using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Srt.Authentication.Models;

namespace Srt.Authentication.Application
{
    public class UsersService : IUsersService
    {
        public async Task<SrtUser> GetUser(SrtUserCredentials credentials)
        {
            HttpClient hc = new HttpClient {BaseAddress = new Uri("http://localhost:9991")};
            var response = await hc.GetAsync("/api/users/" + credentials.UserName);
            var stringContent = response.Content as StringContent;
            var responseString = await stringContent.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SrtUser>(responseString);
        }
    }
}