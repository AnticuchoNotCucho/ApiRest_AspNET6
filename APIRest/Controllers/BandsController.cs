using APIRest.Data.Repositories;
using APIRest.Model;
using Microsoft.AspNetCore.Mvc;


namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BandsController : ControllerBase
    {
        private readonly IBandRepository _bandRepository;

        public BandsController(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBands()
        {
            return Ok(await _bandRepository.GetAllBands());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _bandRepository.GetDetails(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBand([FromBody]Band band)
        {
            if (band == null)
                return BadRequest();
            if (!ModelState.IsValid)
               return BadRequest(ModelState);

            var created = await _bandRepository.InsertBand(band);
            return Created("Created", created);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBand([FromBody]Band band)
        {
            if (band == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           var update = await _bandRepository.UpdateBand(band);

            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBand(int id)
        {
            await _bandRepository.DeleteBand(new Band { idBand = id});
            return NoContent();
        }

    }
}
