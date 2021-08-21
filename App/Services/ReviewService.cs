using AutoFixture;
using Shared.Interfaces;
using Shared.Models;
using System;
using System.Collections.Generic;
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

        public Task<List<Review>> Get()
        {
            return Task.FromResult(fixture.Create<List<Review>>());
        }

        public Task<Review> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Insert(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
