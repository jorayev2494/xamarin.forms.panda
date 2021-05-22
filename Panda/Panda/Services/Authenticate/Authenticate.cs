using Panda.Services.Authenticate.Contracts;
using Panda.Services.HttpService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Panda.Services.Authenticate
{
    public class Authenticate : IAuthenticate
    {
        public async Task<bool> Registration(object data)
        {
            await RestApi.POST("/api/auth/register", data);
            return true;
        }

        public async Task<bool> Login(object data)
        {
            AuthResponse authResponse = await RestApi.POST<AuthResponse>("/api/auth/login", data);

            if (authResponse != null)
            {
                Auth.SetAccessToken(authResponse.AccessToken);
                Auth.SetAuthUser(authResponse.AuthData);
                return true;
            }

            return false;
        }

        public async Task<bool> Logout()
        {
            await RestApi.POST("/api/auth/logout");
            Auth.RemoveAccessToken();
            Auth.RemoveAuthUser();
            return true;
        }
    }
}
