using HR_001.Entities;
using HR_001.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<EducationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EducationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EducationController>
        [HttpPost]
        [Route("add")]
        public IActionResult Post(EducationRequest educationRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var education = new Education
            {
                EducationTypeId = educationRequest.EducationTypeId,
                EmployeeId = educationRequest.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            context.Educations.Add(education);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<EmpBranchController>/5
        [HttpPut]
        [Route("update/{EdId}")]
        public IActionResult Put(int EdId, EducationRequest educationRequest)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            if (EdId != null)
            {

                var education = context.Educations.Where(a => a.Id == 1).First();

                if (education != null)
                {
                    education.EducationTypeId = educationRequest.EducationTypeId;
                    education.EmployeeId = educationRequest.EmployeeId;
                    education.UpdatedDate = DateTime.UtcNow;

                };
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
            }
            return BadRequest();
        }

        // DELETE api/<EducationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
