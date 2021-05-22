using Newtonsoft.Json;
using Panda.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Services.Authenticate
{
    public class AuthResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("auth_data")]
        public User AuthData { get; set; }
    }
}
