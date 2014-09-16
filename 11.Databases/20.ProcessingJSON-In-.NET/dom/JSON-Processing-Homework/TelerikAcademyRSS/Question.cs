using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikAcademyRSS
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    [JsonObject]
    public class Question
    {
        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty]
        public string Link { get; set; }

        [JsonProperty]
        public string Category { get; set; }
    }
}
