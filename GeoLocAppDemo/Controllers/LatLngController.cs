using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using GeoLocAppDemo.Examples.Request;
using GeoLocAppDemo.Models;
using GeoLocAppDemo.Models.GeoLocation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Filters;

namespace GeoLocAppDemo.Controllers
{
    /// <summary>
    /// LatLng controller, used to get the latitude and logitude from the address
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class LatLngController : ControllerBase
    {
        /// <summary>
        /// Gets the latitude and logitude from the address provided
        /// </summary>
        /// <remarks>
        /// Sample **request**:
        ///         GET /latlng/search?address=10+Vukovarska+Split
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<GeoRootObject>> Get([FromQuery] QueryLatLngModel model)
        {
            string url = SetUrl(model);
            List<GeoLocationApiModel> places;
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using var content = response.Content;
                    var result = await content.ReadAsStringAsync();
                    if (result != null)
                    {
                        GeoRootObject root = JsonConvert.DeserializeObject<GeoRootObject>(result);
                        places = root.Results;
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            return Ok(places.FirstOrDefault());
        }

        private string SetUrl(QueryLatLngModel model)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.googleGeocodeUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["address"] = model.Address;

            uriBuilder.Query = query.ToString() + "&key=" + Constants.apiKey;
            return uriBuilder.ToString();
        }
    }
}
