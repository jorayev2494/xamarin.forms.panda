using Newtonsoft.Json;
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

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("color")]
        public System.Drawing.Color Color { get; set; }

        [JsonProperty("image")]
        public ImageSource Image { get; set; }

        public Category()
        {

        }
    }
}
