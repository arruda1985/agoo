using System;

namespace Shared.Models
{
    public class House
    {
        public Guid Id { get; set; }
        public string PostalCode { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
