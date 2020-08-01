using AutoMapper;
using HouseAPI.Domain.Models;
using HouseAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
