using APIRest.Data.Repositories;
using APIRest.Model;
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
        [HttpGet("{idAlbum},{idBands}")]
        public async Task<IActionResult> GetAlbum(int idAlbum, int idBands)
        {
            var result = await _albumRepository.GetAlbum(idAlbum, idBands);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlbum([FromBody] Album album)
        {
            if (album == null)
                return BadRequest();
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            await _albumRepository.InsertAlbum(album);
            return NoContent();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAlbum([FromBody] Album album)
        {
            if (album == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _albumRepository.UpdateAlbum(album);
            return NoContent();

        }
        [HttpDelete("{idBands},{idAlbum}")]
        public async Task<IActionResult> DeleteAlbum(int idBands, int idAlbum)
        {
            if(await _albumRepository.DeleteAlbum(idAlbum, idBands))
                return Ok();
            return NotFound();
        }

            
    }
}
