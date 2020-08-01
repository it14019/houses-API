using System.ComponentModel.DataAnnotations;

namespace HouseAPI.Resources
{
    public class SaveHouseResource
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostCode { get; set; }
    }
}
