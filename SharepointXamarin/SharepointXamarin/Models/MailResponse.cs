using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SharepointXamarin.Models
{
    public class MailResponse : BaseModel
    {
        [JsonProperty("value")]
        public List<Mail> Mail { get; set; }
    }
}
