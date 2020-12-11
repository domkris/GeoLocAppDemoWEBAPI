using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocAppDemo.Models
{
    public class PlaceRootObject
    {
        [JsonProperty("next_page_token")]
        public string NextPageToken { get; set; }

        [JsonProperty("results")]
        public List<PlaceApiModel> Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
