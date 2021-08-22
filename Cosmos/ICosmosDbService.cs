using Shared.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Cosmos
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<House>> GetHouses(string queryString);
        Task<House> GetHouse(string id);
        Task<HttpStatusCode> AddHouse(House item);
        Task<HttpStatusCode> UpdateHouse(string id, House item);
        Task<IEnumerable<Review>> GetReviews(string queryString);
        Task<Review> GetReview(string id);
        Task<HttpStatusCode> AddReview(Review item);
        Task<HttpStatusCode> UpdateReview(string id, Review item);
    }
}