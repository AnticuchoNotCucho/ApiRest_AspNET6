using APIRest.Data.Repositories;
using APIRest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongsRepository _songsRepository;

        public SongsController(ISongsRepository songsRepository)
        {
            _songsRepository = songsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            return Ok(await _songsRepository.GetSongs());
        }

        [HttpGet("{idSongs}/{idAlbum}")]
        public async Task<IActionResult> GetSong(int idSongs, int idAlbum)
        {
            return Ok(await _songsRepository.GetSong(idSongs, idAlbum));
        }
        [HttpPost]
        public async Task<IActionResult> InsertSong(Songs song)
        {
            return Ok(await _songsRepository.InsertSong(song));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSong(Songs song)
        {
            return Ok(await _songsRepository.UpdateSong(song));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSong(int idAlbum, int idSongs)
        {
            return Ok(await _songsRepository.DeleteSong(idAlbum, idSongs));
        }
    }
}
