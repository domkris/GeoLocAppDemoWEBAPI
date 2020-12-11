using GeoLocAppDemo.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocAppDemo.Examples.Request
{
    public class QueryLatLngModelExample : IExamplesProvider<QueryLatLngModel>
    {
        public QueryLatLngModel GetExamples()
        {
            return new QueryLatLngModel
            {
                Address = "10 Vukovarska Split"
            };
        }
    }
}
