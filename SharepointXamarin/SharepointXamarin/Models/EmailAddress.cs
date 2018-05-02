using System;
using Newtonsoft.Json;

namespace SharepointXamarin.Models
{
    public class EmailAddress
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
