using HouseAPI.Domain.Models;

namespace HouseAPI.Domain.Services.Communication
{
    public class ResidentResponse : BaseResponse
    {
        public Resident Resident { get; private set; }

        private ResidentResponse(bool success, string message, Resident resident) : base(success, message)
        {
            Resident = resident;
        }

        public ResidentResponse(Resident resident) : this(true, string.Empty, resident)
        { }

        public ResidentResponse(string message) : this(false, message, null)
        { }
    }
}
