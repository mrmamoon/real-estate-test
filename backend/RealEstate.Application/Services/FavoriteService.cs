using RealEstate.Application.Interfaces;
using RealEstate.Core.Entities;
using RealEstate.Core.Interfaces;
using System.Threading.Tasks;

namespace RealEstate.Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IUserRepository _userRepo;
        private readonly IPropertyRepository _propertyRepo;
        
        public FavoriteService(IUserRepository userRepo, IPropertyRepository propertyRepo)
        {
            _userRepo = userRepo;
            _propertyRepo = propertyRepo;
        }

        public async Task AddFavorite(int userId, int propertyId)
        {
            var user = await _userRepo.GetByIdAsync(userId);
            var property = await _propertyRepo.GetByIdAsync(propertyId);
            
            // Implementation to add favorite
            // You'll need to create a UserFavorite entity and repository
        }
    }
}