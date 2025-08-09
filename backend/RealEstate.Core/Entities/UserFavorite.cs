namespace RealEstate.Core.Entities;

public class UserFavorite
{
    public int UserId { get; set; }
    public User User { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
}