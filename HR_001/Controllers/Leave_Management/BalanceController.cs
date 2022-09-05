using HR_001.Entities.Leave_Management;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers.Leave_Management
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<BalanceController>
        [HttpGet]
        [Route("getBlance/{CompanyId}")]
        public IActionResult Get(int CompanyId)
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.EmployeeBlances.Where(c => c.CompanyId == CompanyId).ToList() });
        }

        // POST api/<BalanceController>
        [HttpPost]
        [Route("add")]
        public IActionResult Post(EmployeeBlance employeeBlance)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var empBalance = new EmployeeBlance
            {
                CompanyId = employeeBlance.CompanyId,
                UserId = employeeBlance.UserId,
                IsMonth = employeeBlance.IsMonth,
                Number = employeeBlance.Number,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            context.EmployeeBlances.Add(empBalance);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<BalanceController>/5
        [HttpPut]
        [Route("update/{empBalanceBalanceId}")]
        public IActionResult Put(int empBalanceBalanceId, EmployeeBlance employeeBlance)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var empBalance = context.EmployeeBlances.Where(j => j.Id == empBalanceBalanceId).FirstOrDefault();
            if (empBalance != null)
            {
                empBalance.CompanyId = employeeBlance.CompanyId;
                empBalance.UserId = employeeBlance.UserId;
                empBalance.IsMonth = employeeBlance.IsMonth;
                empBalance.Number = employeeBlance.Number;
                // empBalance.StatusId = employeeBlance.StatusId;
                empBalance.UpdatedDate = DateTime.UtcNow;

            }
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // DELETE api/<BalanceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
