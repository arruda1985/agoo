using Shared.Dtos;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IHouseService
    {
        Task<House> Get(Guid id);
        Task<IEnumerable<HouseReviews>> Get();
        Task<HttpStatusCode> Insert(House house);
        Task<HttpStatusCode> Update(House house);
        Task<House> GetByPostalCode(string postalCode);
        Task<IEnumerable<HouseReviews>> GetByPostalCodeAndNumber(string postalCode, string number);
    }
}
