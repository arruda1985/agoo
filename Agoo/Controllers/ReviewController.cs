using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Agoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet("{id}")]
        public async Task<Review> Get(Guid id)
        {
            return await reviewService.Get(id);
        }

        public async Task<IEnumerable<Review>> Get()
        {
            return await reviewService.Get();
        }

        public async Task<HttpStatusCode> Post(Review review)
        {
            return await reviewService.Insert(review);
        }

        public async Task<HttpStatusCode> Patch(Review review)
        {
            return await reviewService.Update(review);
        }
    }
}
