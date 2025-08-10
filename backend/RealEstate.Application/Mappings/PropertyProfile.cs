using AutoMapper;
using RealEstate.Application.DTOs;
using RealEstate.Core.Entities;

namespace RealEstate.Application.Mappings
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<Property, PropertyDto>();
            CreateMap<Property, PropertyDetailsDto>();
        }
    }
}