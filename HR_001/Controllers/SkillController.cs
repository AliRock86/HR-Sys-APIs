using HR_001.Entities;
using HR_001.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<SkillController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SkillController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SkillController>
        [HttpPost]
        [Route("Add")]
        public IActionResult Post(SkillRequest skillRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var skill = new Skill
            {
                EmployeeId = skillRequest.EmployeeId,
                SkillName = skillRequest.SkillName,
                CreatedDate = skillRequest.CreatedDate,
                UpdatedDate = skillRequest.UpdatedDate,

            };
            context.Skills.Add(skill);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<skillController>/5
        [HttpPut]
        [Route("update/{skillId}")]
        public IActionResult Put(int skillId, SkillRequest skillRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var skill = context.Skills.Where(j => j.Id == skillId).FirstOrDefault();
            if (skill != null)
            {
                skill.EmployeeId = skillRequest.EmployeeId;
                skill.SkillName = skillRequest.SkillName;
                skill.CreatedDate = skillRequest.CreatedDate;
                skill.UpdatedDate = skillRequest.UpdatedDate;

            }
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // DELETE api/<SkillController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
