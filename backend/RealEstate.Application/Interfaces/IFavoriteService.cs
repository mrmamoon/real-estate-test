using System.Threading.Tasks;

namespace RealEstate.Application.Interfaces
{
    public interface IFavoriteService
    {
        Task AddFavorite(int userId, int propertyId);
    }
}