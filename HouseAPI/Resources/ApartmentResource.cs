using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseAPI.Resources
{
    public class ApartmentResource
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public double PropertySize { get; set; }
        public double LivingArea { get; set; }
        public int HouseId { get; set; } 
        public HouseResource House { get; set; }
    }
}
