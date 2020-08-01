using HouseAPI.Domain.Models;
using HouseAPI.Resources;
using AutoMapper;

namespace HouseAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<House, HouseResource>();
            CreateMap<Apartment, ApartmentResource>();
            CreateMap<Resident, ResidentResource>();
        }
    }
}
