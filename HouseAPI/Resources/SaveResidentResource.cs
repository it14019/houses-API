﻿namespace HouseAPI.Resources
{
    public class SaveResidentResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalCode { get; set; }
        public string BirthDate { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }

        public int ApartmentId { get; set; }
    }
}
