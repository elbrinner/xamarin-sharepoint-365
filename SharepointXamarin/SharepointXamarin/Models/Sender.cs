using Newtonsoft.Json;

namespace SharepointXamarin.Models
{
    public class Sender
    {
        [JsonProperty("emailAddress")]
        public EmailAddress EmailAddress { get; set; }
    }
}