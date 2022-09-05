using HR_001.Entities;
using HR_001.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<JobController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JobController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JobController>
        [HttpPost]
        [Route("Add")]
        public IActionResult Post(JobRequest jobRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var job = new JobTitle
            {
                EmployeeId = jobRequest.EmployeeId,
                JobTypeId = jobRequest.JobTypeId,
                CreatedDate = jobRequest.CreatedDate,
                UpdatedDate = jobRequest.UpdatedDate,

            };
            context.JobTitles.Add(job);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<JobController>/5
        [HttpPut]
        [Route("update/{JobId}")]
        public IActionResult Put(int JobId, JobRequest jobRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var job = context.JobTitles.Where(j => j.Id == JobId).FirstOrDefault();
            if(job != null)
            {
                job.EmployeeId = jobRequest.EmployeeId;
                job.JobTypeId = jobRequest.JobTypeId;
                job.UpdatedDate = jobRequest.UpdatedDate;
            }
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
