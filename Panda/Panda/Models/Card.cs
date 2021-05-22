using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Panda.Models
{
    public class Card : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonIgnore, JsonProperty("image")]
        public ImageSource Image { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("expires_end")]
        public string ExpiresEnd { get; set; }

        [JsonProperty("security_code")]
        public int SecurityCode { get; set; }

        [JsonProperty("type_card")]
        public string TypeCard { get; set; }
    }
}
