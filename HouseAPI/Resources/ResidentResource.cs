using HouseAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseAPI.Resources
{
    public class ResidentResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalCode { get; set; }
        public string BirthDate { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }

        public int ApartmentId { get; set; }
        public ApartmentResource Apartment { get; set; }
    }
}
