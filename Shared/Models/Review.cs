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
       
        [JsonProperty(PropertyName = "fullReview")]
        public string FullReview { get; set; }
      
        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "houseId")]
        public Guid HouseId { get; set; }
    }
}
