using RealEstate.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RealEstate.Core.Interfaces
{
    public interface IPropertyRepository
    {
        Task<IEnumerable<Property>> GetAllAsync();
        Task<Property?> GetByIdAsync(int id);
    }

    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task<bool> SaveAllAsync();
    }
}