using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Models
{
    public class Size : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("is_have")]
        public bool IsHave { get; set; }
    }
}
