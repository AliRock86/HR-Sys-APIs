using HR_001.Entities.Leave_Management;
using HR_001.Requests.Leave_Management;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers.Leave_Management
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidaysController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<HolidaysController>
        [HttpGet]
        [Route("getAll/CompanyId")]
        public IActionResult Get(int CompanyId)
        {
            var holidays = context.Holidays.Where(j => j.CompanyId == CompanyId).ToList();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = holidays });
        }

        // POST api/<HolidaysController>
        [HttpPost]
        [Route("add")]
        public IActionResult Post(HolidaysRequest holidaysRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var holiday = new Holidays
            {
                FromDate = holidaysRequest.FromDate,
                ToDate = holidaysRequest.ToDate,
                CompanyId = holidaysRequest.CompanyId,
                Description = holidaysRequest.Description,

            };

            context.Holidays.Add(holiday);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<HolidaysController>/5
        [HttpPut]
        [Route("update/{HolidaysId}")]
        public IActionResult Put(int HolidaysId, HolidaysRequest holidaysRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            } 

            var holidays = context.Holidays.Where(j => j.Id == HolidaysId).FirstOrDefault();
            if (holidays != null)
            {
                holidays.FromDate = holidaysRequest.FromDate;
                holidays.ToDate = holidaysRequest.ToDate;
                holidays.CompanyId = holidaysRequest.CompanyId;
                holidays.Description = holidaysRequest.Description;

            }
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // DELETE api/<HolidaysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
