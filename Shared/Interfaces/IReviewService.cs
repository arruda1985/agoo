using Shared.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IReviewService
    {
        Task<Review> Get(Guid id);
        Task<List<Review>> Get();
        Task<HttpStatusCode> Insert(Review review);
        Task<HttpStatusCode> Update(Review review);
    }
}
