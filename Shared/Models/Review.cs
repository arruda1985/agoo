using Newtonsoft.Json;
using System;

namespace Shared.Models
{
    public class Review
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }
      
        [JsonProperty(PropertyName = "stars")]
        public int Stars { get; set; }
       
        [JsonProperty(PropertyName = "neighborhood")]
        public string Neighborhood { get; set; }
        
        [JsonProperty(PropertyName = "structure")]
        public string Structure { get; set; }
      
        [JsonProperty(PropertyName = "landLord")]
        public string LandLord { get; set; }

        [JsonProperty(PropertyName = "general")]
        public string General { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "houseId")]
        public Guid HouseId { get; set; }
    }
}
