using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RealEstate.Application.DTOs;
using RealEstate.Application.Interfaces;
using RealEstate.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RealEstate.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _repo;
        private readonly IMapper _mapper;
        
        public PropertyService(IPropertyRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PropertyDto>> GetAllPropertiesAsync(PropertySearchDto searchParams = null)
        {
            var query = _repo.GetQueryable();
            
            // Apply filters
            if (searchParams != null)
            {
                if (searchParams.MinPrice.HasValue)
                    query = query.Where(p => p.Price >= searchParams.MinPrice.Value);
                
                if (searchParams.MaxPrice.HasValue)
                    query = query.Where(p => p.Price <= searchParams.MaxPrice.Value);
                
                if (searchParams.MinBedrooms.HasValue)
                    query = query.Where(p => p.Bedrooms >= searchParams.MinBedrooms.Value);
                
                if (searchParams.MaxBedrooms.HasValue)
                    query = query.Where(p => p.Bedrooms <= searchParams.MaxBedrooms.Value);
                
                if (searchParams.MinBathrooms.HasValue)
                    query = query.Where(p => p.Bathrooms >= searchParams.MinBathrooms.Value);
                
                if (searchParams.MaxBathrooms.HasValue)
                    query = query.Where(p => p.Bathrooms <= searchParams.MaxBathrooms.Value);
                
                if (!string.IsNullOrWhiteSpace(searchParams.Address))
                    query = query.Where(p => p.Address.Contains(searchParams.Address));
            }

            var properties = await query.ToListAsync();
            return _mapper.Map<IEnumerable<PropertyDto>>(properties);
        }

        public async Task<PropertyDetailsDto> GetPropertyByIdAsync(int id)
        {
            var property = await _repo.GetByIdAsync(id);
            return _mapper.Map<PropertyDetailsDto>(property);
        }
    }
}