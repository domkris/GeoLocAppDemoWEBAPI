using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoLocAppDemo.Models
{
    public class PlaceApiModel
    {
        [JsonProperty("business_status")]
        public string BussinesStatus { get; set; }

        [JsonProperty("geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty("Icon")]
        public string Icon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("opening_hours")]
        public OpeningHours OpeningHours { get; set; }

        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }

        [JsonProperty("place_id")]
        public string Placeid { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }

        [JsonProperty("user_ratings_total")]
        public int UserRatings { get; set; }

        [JsonProperty("vicinity")]
        public string Vicinity { get; set; }
    }

    public class Photo
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("photo_reference")]
        public string PhotoReference { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }
    }

    public class OpeningHours
    {
        [JsonProperty("open_now")]
        public bool OpenNow { get; set; }
    }

    public class Geometry
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("viewport")]
        public Viewport Viewport { get; set; }
    }

    public class Viewport
    {
        [JsonProperty("northeast")]
        public Location NorthEast { get; set; }

        [JsonProperty("southwest")]
        public Location SouthWest { get; set; }
    }

    public class Location
    {
        [JsonProperty("lat")]
        public decimal Latitude { get; set; }

        [JsonProperty("lng")]
        public decimal Longitude { get; set; }
    }
}
