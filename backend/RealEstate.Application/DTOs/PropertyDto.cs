using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.DTOs;


public class PropertyDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public int Bedrooms { get; set; }
    public string Description { get; set; }
    public int Bathrooms { get; set; }

}


public class PropertyDetailsDto : PropertyDto
{
    public string Description { get; set; }
    public int Bathrooms { get; set; }
}
