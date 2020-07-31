using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseAPI.Domain.Models
{
    public class House
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public IList<Apartment> Apartments { get; set; } = new List<Apartment>();
    }
}
