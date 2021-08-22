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
        private readonly Container _containerHouse;
        private readonly Container _containerReview;

        public CosmosDbService(
              CosmosClient dbClient,
              string databaseName)
        {
            this._containerHouse = dbClient.GetContainer(databaseName, "Houses");
            this._containerReview = dbClient.GetContainer(databaseName, "Reviews");

        }

        public async Task<HttpStatusCode> AddHouse(House item)
        {
            var response = await _containerHouse.CreateItemAsync(item, new PartitionKey(item.Id.ToString()));

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> AddReview(Review item)
        {
            var response = await _containerReview.CreateItemAsync(item, new PartitionKey(item.Id.ToString()));

            return response.StatusCode;
        }


        public async Task<House> GetHouse(string id)
        {
            try
            {
                ItemResponse<House> response = await _containerHouse.ReadItemAsync<House>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<House>> GetHouses(string queryString)
        {
            var query = _containerHouse.GetItemQueryIterator<House>(new QueryDefinition(queryString));
            var results = new List<House>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<Review> GetReview(string id)
        {
            try
            {
                ItemResponse<Review> response = await _containerReview.ReadItemAsync<Review>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Review>> GetReviews(string queryString)
        {
            var query = _containerReview.GetItemQueryIterator<Review>(new QueryDefinition(queryString));
            var results = new List<Review>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task<HttpStatusCode> UpdateHouse(string id, House item)
        {
            var response = await _containerHouse.UpsertItemAsync(item, new PartitionKey(id));

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> UpdateReview(string id, Review item)
        {
            var response = await _containerReview.UpsertItemAsync(item, new PartitionKey(id));

            return response.StatusCode;
        }
    }
}
