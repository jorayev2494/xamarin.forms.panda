using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Panda.Models
{
    public class Product : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("sale_price")]
        public double SalePrice { get; set; }

        [JsonProperty("cover")]
        public ImageSource Cover { get; set; }

        [JsonProperty("images")]
        public IList<ImageSource> Images { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("sizes")]
        public IList<Size> Sizes { get; set; }

        [JsonProperty("colors")]
        public IList<Color> Colors { get; set; }
    }
}
