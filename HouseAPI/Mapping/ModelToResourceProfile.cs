using HouseAPI.Domain.Models;
using HouseAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace HouseAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<House, HouseResource>();
            CreateMap<Apartment, ApartmentResource>();
        }
    }
}
