using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Models
{
    public class Address : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("address_street")]
        public string AddressStreet { get; set; }

        [JsonProperty("address_lane")]
        public string AddressLane { get; set; }

        [JsonProperty("postal_code")]
        public int PostalCode { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
