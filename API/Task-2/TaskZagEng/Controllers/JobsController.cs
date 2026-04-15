using Microsoft.AspNetCore.Mvc;
using TaskZagEng.Data;
using TaskZagEng.Filters;
using TaskZagEng.Services;

namespace TaskZagEng.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        //Get Job
        [HttpGet]
        public ActionResult<IEnumerable<JobListing>> GetAll()
        {
            var jobs = _jobService.GetAllActive();
            return Ok(jobs);
        }

        //Get Job ID
        [HttpGet("{id:int}")]
        public ActionResult<JobListing> GetById(int id)
        {
            var job = _jobService.GetById(id);
            if (job is null)
                return NotFound($"Job with ID {id} was not found.");

            return Ok(job);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateJobFilter))]
        public ActionResult<JobListing> Create([FromBody] JobListing job)
        {
            _jobService.Create(job);
            return CreatedAtAction(nameof(GetById), new { id = job.Id }, job);
        }

        [HttpPut("{id:int}")]
        [ServiceFilter(typeof(ValidateJobFilter))]
        public IActionResult Update(int id, [FromBody] JobListing job)
        {
            try
            {
                _jobService.Update(id, job);
                return Ok(_jobService.GetById(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _jobService.SoftDelete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
