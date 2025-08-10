using System.Collections.Generic;
using System.Threading.Tasks;
using RealEstate.Application.DTOs;

namespace RealEstate.Application.Interfaces
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyDto>> GetAllPropertiesAsync(PropertySearchDto searchParams = null);
        Task<PropertyDetailsDto> GetPropertyByIdAsync(int id);
    }

}