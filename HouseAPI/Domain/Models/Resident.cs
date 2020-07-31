using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseAPI.Domain.Models
{
    public class Resident
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PersonalCode { get; set; }
        public int BirthDate { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
    }
}
