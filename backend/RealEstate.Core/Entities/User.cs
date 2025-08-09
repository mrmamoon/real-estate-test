namespace RealEstate.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public ICollection<UserFavorite> Favorites { get; set; }
}