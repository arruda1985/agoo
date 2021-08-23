using AutoFixture;
using Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Dtos;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace App.Services
{
    public class HouseService : IHouseService
    {
        private readonly ICosmosDbService _cosmosDbService;
        static readonly HttpClient client = new HttpClient();

        public HouseService(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }
        public async Task<House> Get(Guid id)
        {
            return await _cosmosDbService.GetHouse(id.ToString());
        }

        public async Task<IEnumerable<HouseReviews>> Get()
        {
            var houseReviews = new List<HouseReviews>();
            var houses = _cosmosDbService.GetHouses("SELECT * FROM c").Result.ToList();

            for (int i = 0; i < houses.Count; i++)
            {

                houseReviews.Add(new HouseReviews
                {
                    House = houses[0],
                    Reviews = await _cosmosDbService.GetReviews($"SELECT * FROM c WHERE c.HouseId = '{houses[0].Id}'")
                });

            }

            return houseReviews;
        }

        public async Task<House> GetByPostalCode(string postalCode)
        {
            var postalApi = $"https://viacep.com.br/ws/{postalCode}/json";

            HttpResponseMessage response = await client.GetAsync(postalApi);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var jsonBody = JObject.Parse(responseBody);

            return new House()
            {
                PostalCode = postalCode,
                StreetName = jsonBody["logradouro"].ToString(),
                Neighborhood = jsonBody["bairro"].ToString(),
                City = jsonBody["localidade"].ToString(),
                State = jsonBody["uf"].ToString(),
                Country = "Brasil"

            };
        }

        public async Task<HttpStatusCode> Insert(House house)
        {
            house.Id = Guid.NewGuid();
            return await _cosmosDbService.AddHouse(house);
        }

        public async Task<HttpStatusCode> Update(House house)
        {
            return await _cosmosDbService.UpdateHouse(house.Id.ToString(), house);
        }
    }
}
