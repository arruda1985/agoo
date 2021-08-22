using AutoFixture;
using Cosmos;
using Newtonsoft.Json;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace App.Services
{
    public class HouseService : IHouseService
    {
        private readonly ICosmosDbService _cosmosDbService;

        public HouseService(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }
        public async Task<House> Get(Guid id)
        {
            return await _cosmosDbService.GetItemAsync(id.ToString());
        }

        public async Task<IEnumerable<House>> Get()
        {
            return await _cosmosDbService.GetItemsAsync("SELECT * FROM c");
        }

        public async Task<HttpStatusCode> Insert(House house)
        {
            return await _cosmosDbService.AddItemAsync(house);
        }

        public async Task<HttpStatusCode> Update(House house)
        {
            return await _cosmosDbService.UpdateItemAsync(house.Id.ToString(), house);
        }
    }
}
