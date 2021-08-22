using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Dtos
{
    public class HouseReviews
    {
        public House House { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
