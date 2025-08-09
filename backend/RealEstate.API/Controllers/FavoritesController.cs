using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Interfaces;
using RealEstate.API.Helpers;

namespace RealEstate.API.Controllers
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IUserAccessor _userAccessor; // Gets current user ID from JWT

        public FavoritesController(IFavoriteService favoriteService, IUserAccessor userAccessor)
        {
            _favoriteService = favoriteService;
            _userAccessor = userAccessor;
        }
        
        [HttpPost("{propertyId}")]
        public async Task<ActionResult> AddFavorite(int propertyId)
        {
            await _favoriteService.AddFavorite(_userAccessor.GetUserId(), propertyId);
            return Ok();
        }
    }
}