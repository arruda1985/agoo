using App.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Interfaces;
using Shared.Models;
using System.Net;
using System.Threading.Tasks;

namespace Agoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<HttpStatusCode> Post(Review review)
        {
            return await _reviewService.Insert(review);
        }
    }
}
