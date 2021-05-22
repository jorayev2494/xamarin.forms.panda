using Newtonsoft.Json;
using Panda.Services.HttpService;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;

namespace Panda.Models
{
    public class Category : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("color")]
        public System.Drawing.Color Color { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonIgnore]
        public string GetImage {
            get => $"{RestApi.URL}/{this.Image}";
        }

        public Category()
        {

        }
    }
}
