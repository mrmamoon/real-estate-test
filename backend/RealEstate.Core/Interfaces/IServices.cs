using RealEstate.Core.Entities;

namespace RealEstate.Core.Interfaces
{
    public interface IAuthService
    {
        string CreateToken(User user);
        void CreatePasswordHash(string password, out byte[] hash, out byte[] salt);
    }
}