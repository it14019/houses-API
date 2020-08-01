using HouseAPI.Domain.Models;

namespace HouseAPI.Domain.Services.Communication
{
    public class ApartmentResponse : BaseResponse
    {
        public Apartment Apartment { get; private set; }

        private ApartmentResponse(bool success, string message, Apartment apartment) : base(success, message)
        {
            Apartment = apartment;
        }

        public ApartmentResponse(Apartment apartment) : this(true, string.Empty, apartment)
        { }

        public ApartmentResponse(string message) : this(false, message, null)
        { }
    }
}
