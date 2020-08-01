using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseAPI.Domain.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public double PropertySize { get; set; }
        public double LivingArea { get; set; }

        public int HouseId { get; set; }
        public House House { get; set; }

        public IList<Resident> Residents { get; set; } = new List<Resident>();
    }
}
