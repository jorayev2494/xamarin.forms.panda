
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Models
{
    public class User : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }
}
