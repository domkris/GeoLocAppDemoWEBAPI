using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using GeoLocAppDemo.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using GeoLocAppDemo.Models.GeoLocation;

namespace GeoLocAppDemo.Controllers
{
    /// <summary>
    /// Address controller, used to get the address from the latiitude and logitude
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        /// <summary>
        /// Gets  the address from the langitude and longitude provided
        /// </summary>
        /// /// <remarks>
        /// Sample **request**:
        ///         GET /address/?latlng=23,24
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<GeoLocationApiModel>> Get([FromQuery] QueryAddressModel model)
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

        private string SetUrl(QueryAddressModel model)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.googleGeocodeUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["latlng"] = model.LatLng;

            uriBuilder.Query = query.ToString() + "&key=" + Constants.apiKey;
            return uriBuilder.ToString();
        }
    }
}
