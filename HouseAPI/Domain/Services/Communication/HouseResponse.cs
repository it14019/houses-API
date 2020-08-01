using HouseAPI.Domain.Models;

namespace HouseAPI.Domain.Services.Communication
{
    public class HouseResponse : BaseResponse
    {
        public House House { get; private set; }

        private HouseResponse(bool success, string message, House house) : base(success,message)
        {
            House = house;
        }

        public HouseResponse(House house) : this(true, string.Empty, house)
        { }

        public HouseResponse(string message) : this(false, message, null)
        { }
    }

}
