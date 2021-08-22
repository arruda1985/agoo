using Shared.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IHouseService
    {
        Task<House> Get(Guid id);
        Task<IEnumerable<House>> Get();
        Task<HttpStatusCode> Insert(House house);
        Task<HttpStatusCode> Update(House house);
    }
}
