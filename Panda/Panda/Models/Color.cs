using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Panda.Models
{
    public class Color : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("slug")]
        public Xamarin.Forms.Color Slug { get; set; }

        [JsonProperty("is_have")]
        public bool IsHave { get; set; }

    }
}
