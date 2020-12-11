using GeoLocAppDemo.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocAppDemo.Examples.Request
{
    public class QueryAddressModelExample : IExamplesProvider<QueryAddressModel>
    {
        public QueryAddressModel GetExamples()
        {
            return new QueryAddressModel
            {
                LatLng = "51.5074,0.1278"
            };
        }
    }
}
