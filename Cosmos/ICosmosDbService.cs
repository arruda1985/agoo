using Shared.Models;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Cosmos
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<House>> GetItemsAsync(string queryString);
        Task<House> GetItemAsync(string id);
        Task<HttpStatusCode> AddItemAsync(House item);
        Task<HttpStatusCode> UpdateItemAsync(string id, House item);
        Task DeleteItemAsync(string id);
    }
}