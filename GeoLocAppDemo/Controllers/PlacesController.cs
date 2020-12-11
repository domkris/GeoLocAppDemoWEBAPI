using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using GeoLocAppDemo.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeoLocAppDemo.Controllers
{
    /// <summary>
    /// Places controller, used to get the places
    /// </summary>
    [EnableCors("AllowOrigin")]
    [Route("[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        /// <summary>
        /// Gets the places specified by location ,type radius and keyword
        /// </summary>
        /// /// <remarks>
        /// Sample **request**:
        ///         GET /places/?location=51.5074,0.1278/radius=1500/type=restaurant
        /// </remarks>
        [HttpGet]
        public async Task<ActionResult<List<PlaceApiModel>>> Get([FromQuery] QueryPlaceModel model)
        {

            string url = SetUrl(model);
            List<PlaceApiModel> places;
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    using var content = response.Content;
                    var result = await content.ReadAsStringAsync();
                    if (result != null)
                    {
                        PlaceRootObject root = JsonConvert.DeserializeObject<PlaceRootObject>(result);
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
            return Ok(places);
        }

        //https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=-33.8670522,151.1957362&radius=1500&type=restaurant&keyword=cruise&key=AIzaSyCuyfl0Mrz1GNYIdHKfL6u_3jNSQIvyOng
        private string SetUrl(QueryPlaceModel model)
        {
            UriBuilder uriBuilder = new UriBuilder(Constants.googlePlacesUrl);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["location"] = model.Location;
            query["radius"] = model.Radius;
            query["type"] = model.Type;
            query["keyword"] = model.Keyword;

            uriBuilder.Query = query.ToString() + "&key=" + Constants.apiKey;
            return uriBuilder.ToString();
        }
    }
}
