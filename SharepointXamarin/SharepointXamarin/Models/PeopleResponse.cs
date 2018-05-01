using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SharepointXamarin.Models
{
    public class PeopleResponse : BaseModel
    {
        [JsonProperty("value")]
        public List<People> Peoples { get; set; }
    }
}
