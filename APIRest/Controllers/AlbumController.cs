using APIRest.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumController(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAlbums()
        {
            return Ok(await _albumRepository.GetAllAlbums());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            return Ok( await _albumRepository.GetAlbum(id));
        }

            
    }
}
