using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.DTOs;
using RealEstate.Core.Interfaces;
using RealEstate.Infrastructure.Data;
using RealEstate.Core.Entities;

namespace RealEstate.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepo;

        public AuthController(IAuthService authService, IUserRepository userRepository)
        {
            _authService = authService;
            _userRepo = userRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterDto dto)
        {
            // Validate & create user
            _authService.CreatePasswordHash(dto.Password, out byte[] hash, out byte[] salt);
            var user = new User { Email = dto.Email, PasswordHash = hash, PasswordSalt = salt };
            
            _userRepo.AddAsync(user);
            await _userRepo.SaveAllAsync();
            
            return Ok(new { token = _authService.CreateToken(user) });
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDto dto)
        {
            var user = await _userRepo.GetByEmailAsync(dto.Email);

            if (user == null)
                return Unauthorized("Invalid email or password");
            if(!_authService.VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized("Invalid email or password");

            
            return Ok(new {token = _authService.CreateToken(user)});

        }
    }
}