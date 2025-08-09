using System.ComponentModel.DataAnnotations;

namespace RealEstate.Application.DTOs;

public class UserRegisterDto
{
    [Required, EmailAddress]
    public string Email { get; set; }
    
    [Required, StringLength(100, MinimumLength = 6)]
    public string Password { get; set; }
}