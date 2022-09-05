using HR_001.Entities;
using HR_001.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<SalaryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SalaryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SalaryController>
        [HttpPost]
        [Route("Add")]
        public IActionResult Post(SalaryRequest salaryRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var salary = new Salary
            {
                EmployeeId = salaryRequest.EmployeeId,
                Value = salaryRequest.Value,
                CreatedDate = salaryRequest.CreatedDate,
                UpdatedDate = salaryRequest.UpdatedDate,
                IsUSD = salaryRequest.IsUSD,

            };
            context.Salaries.Add(salary);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<SalaryController>/5
        [HttpPut]
        [Route("update/{SalaryId}")]
        public IActionResult Put(int SalaryId, SalaryRequest salaryRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var salary = context.Salaries.Where(j => j.Id == SalaryId).FirstOrDefault();
            if (salary != null)
            {
                salary.EmployeeId = salaryRequest.EmployeeId;
                salary.Value = salaryRequest.Value;
                salary.CreatedDate = salaryRequest.CreatedDate;
                salary.UpdatedDate = salaryRequest.UpdatedDate;
                salary.IsUSD = salaryRequest.IsUSD;

            }
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // DELETE api/<SalaryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
