using Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IReviewService
    {
        Task<Review> Get(Guid id);
        Task<List<Review>> Get();
        Task<Guid> Insert(Review review);
    }
}
