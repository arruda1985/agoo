using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cosmos
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Review>> GetItemsAsync(string queryString);
        Task<Review> GetItemAsync(string id);
        Task AddItemAsync(Review item);
        Task UpdateItemAsync(string id, Review item);
        Task DeleteItemAsync(string id);
    }
}