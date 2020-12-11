using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocAppDemo.Models.GeoLocation
{
    public class GeoRootObject
    {
        [JsonProperty("plus_code")]
        public PlusCode PlusCode { get; set; }

        [JsonProperty("results")]
        public List<GeoLocationApiModel> Results { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
