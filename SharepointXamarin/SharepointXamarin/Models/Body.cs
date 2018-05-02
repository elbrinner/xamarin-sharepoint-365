using Newtonsoft.Json;

namespace SharepointXamarin.Models
{
    public class Body
    {
        [JsonProperty("contentType")]
        public string ContentType { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}