using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Agoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService houseService;

        public HouseController(IHouseService houseService)
        {
            this.houseService = houseService;
        }

        [HttpGet("{id}")]
        public async Task<House> Get(Guid id)
        {
            return await houseService.Get(id);
        }

        public async Task<IEnumerable<HouseReviews>> Get()
        {
            return await houseService.Get();
        }

        [HttpPost]
        public async Task<HttpStatusCode> Post(House house)
        {
            return await houseService.Insert(house);
        }

        [HttpPatch]
        public async Task<HttpStatusCode> Patch(House house)
        {
            return await houseService.Update(house);
        }
    }
}
