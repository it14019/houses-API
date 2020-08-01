namespace HouseAPI.Resources
{
    public class SaveApartmentResource
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public int Rooms { get; set; }
        public double PropertySize { get; set; }
        public double LivingArea { get; set; }

        public int HouseId { get; set; } 
    }
}
