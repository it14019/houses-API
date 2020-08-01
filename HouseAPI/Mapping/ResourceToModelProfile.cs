using AutoMapper;
using HouseAPI.Domain.Models;
using HouseAPI.Resources;

namespace HouseAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveHouseResource, House>();
            CreateMap<SaveApartmentResource, Apartment>();
            CreateMap<SaveResidentResource, Resident>();
        }
    }
}
