using System;

namespace Srt.Authentication.Application
{
    public static class TokenUtility
    {
        public static string GetToken(string credentialsUserName)
        {
            return credentialsUserName + "___token";
        }
    }
}