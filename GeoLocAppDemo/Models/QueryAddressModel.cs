using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocAppDemo.Models
{
    public class QueryAddressModel
    {
        [FromQuery]
        public string LatLng { get; set; }
    }
}
