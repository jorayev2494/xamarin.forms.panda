using Newtonsoft.Json;
using Panda.Services.HttpService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Models
{
    public class File : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public ulong Size { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("user_file_name")]
        public string UserFileName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public string GetUrl
        {
            get => $"{RestApi.URL}{this.Url}";
        }
    }
}
