using System;

namespace Shared.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public House House { get; set; }
        public int Stars { get; set; }
        public string FullReview { get; set; }
    }
}
