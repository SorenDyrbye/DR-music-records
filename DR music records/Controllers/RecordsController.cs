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
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetRecordById(int id)
        {
            var record = _repo.GetById(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddRecord([FromBody] Records record)
        {
            var createdRecord = _repo.Add(record);
            return Created ($"/api/records/{createdRecord.Id}", createdRecord);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteRecord(int id)
        {
            var deletedRecord = _repo.Delete(id);
            if (deletedRecord == null)
            {
                return NotFound();
            }
            return Ok(deletedRecord);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateRecord(int id, [FromBody] Records data)
        {
            var updatedRecord = _repo.Update(id, data);
            if (updatedRecord == null)
            {
                return NotFound();
            }
            return Ok(updatedRecord);
        }
    }
}
