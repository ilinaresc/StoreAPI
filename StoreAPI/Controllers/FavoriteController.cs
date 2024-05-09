using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreDOMAIN.Core.Entities;
using StoreDOMAIN.Core.Interfaces;


namespace StoreDOMAIN.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var favorites = await _favoriteRepository.GetAll();
            return Ok(favorites);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var favorite = await _favoriteRepository.GetById(id);
            if (favorite == null)
                return NotFound();

            return Ok(favorite);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Favorite favorite)
        {
            var result = await _favoriteRepository.Insert(favorite);
            if (!result) return BadRequest();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _favoriteRepository.Delete(id);
            if (!result)
                return BadRequest();
            return Ok(result);
        }
    }
}