using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocAppDemo.Models
{
    public class QueryPlaceModel
    {
        [FromQuery]
        public string Location { get; set; }
        [FromQuery]
        public string Radius { get; set; }
        [FromQuery]
        public string Type { get; set; }
        [FromQuery]
        public string Keyword { get; set; }
    }
}
