using Microsoft.Azure.Cosmos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos
{
    public class CosmosDbService : ICosmosDbService
    {
        private readonly Container _container;

        public CosmosDbService(
              CosmosClient dbClient,
              string databaseName,
              string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);
        }

        public async Task AddItemAsync(Review item)
        {
            await _container.CreateItemAsync<Review>(item, new PartitionKey(item.Id.ToString()));
        }

        public Task DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Review> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<Review> response = await _container.ReadItemAsync<Review>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Review>> GetItemsAsync(string queryString)
        {
            var query = this._container.GetItemQueryIterator<Review>(new QueryDefinition(queryString));
            var results = new List<Review>();
           
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public Task UpdateItemAsync(string id, Review item)
        {
            throw new NotImplementedException();
        }
    }
}
