using GeoLocAppDemo.Models;
using GeoLocAppDemo.Models.GeoLocation;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocAppDemo.Examples.Request
{
    public class QueryPlaceModelExample : IExamplesProvider<QueryPlaceModel>
    {
        public QueryPlaceModel GetExamples()
        {
            return new QueryPlaceModel
            {
                Location = "51.5074,0.1278",
                Radius = "1000",
                Keyword = null
            };
        }
    }
}
