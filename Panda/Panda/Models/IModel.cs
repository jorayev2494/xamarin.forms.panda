using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Models
{
    public interface IModel
    {
        [JsonProperty("id")]
        int Id { get; set; }

    }
}
