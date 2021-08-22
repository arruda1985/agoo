using Microsoft.Azure.Cosmos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<HttpStatusCode> AddItemAsync(House item)
        {
            var response = await _container.CreateItemAsync<House>(item, new PartitionKey(item.Id.ToString()));

            return response.StatusCode;
        }

        public Task DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<House> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<House> response = await _container.ReadItemAsync<House>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<House>> GetItemsAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<House>(new QueryDefinition(queryString));
            var results = new List<House>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<HttpStatusCode> UpdateItemAsync(string id, House item)
        {
            var response = await _container.UpsertItemAsync<House>(item, new PartitionKey(id));

            return response.StatusCode;
        }
    }
}
