using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DR_music_records.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly RecordsRepository _repo;

        public RecordsController(RecordsRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetallRecords([FromQuery] string? title = null, [FromQuery] string? artist = null)
        {
          
            return Ok(_repo.GetAllRecords(title, artist));
        }
    }
}
