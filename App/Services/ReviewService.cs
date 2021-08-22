using AutoFixture;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace App.Services
{
    public class ReviewService : IReviewService
    {
        private readonly Fixture fixture;

        public ReviewService()
        {
            fixture = new Fixture();
        }

        public Task<Review> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Review>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Insert(Review review)
        {
            throw new NotImplementedException();
        }

        public Task<HttpStatusCode> Update(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
