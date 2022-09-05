using HR_001.Entities.Leave_Management;
using HR_001.Requests.Leave_Management;
using HR_001.Validations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers.Leave_Management
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacationController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        VacationValidation vacationValidation = new VacationValidation();

        [Route("getVacations/{empId}")]
        public IActionResult Get(int empId)
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.Vacations.Where(c => c.EmployeeId == empId).ToList() });
        }

        [HttpPost]  
        public IActionResult Post(VacationRequest vacationRequest)
        {
            DateTime from = Convert.ToDateTime(vacationRequest.FromDate);
            DateTime to = Convert.ToDateTime(vacationRequest.ToDate);
            int num= to.Month - from.Month;
            bool res = vacationValidation.VacationAvailability(vacationRequest.EmployeeId, vacationRequest.CompanyId, num ,vacationRequest.VacationTypeId);


            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            if(!res)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, new { status = false, message = "did not have enough vacation balance" });
            }

            var vacation = new Vacation
            {
                FromDate = vacationRequest.FromDate,
                ToDate = vacationRequest.ToDate,
                EmployeeId = vacationRequest.EmployeeId,
                EmployeeReplaceId = vacationRequest.EmployeeReplaceId,
                Description = vacationRequest.Description,
                VacationTypeId = vacationRequest.VacationTypeId,
                StatusId = vacationRequest.StatusId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            context.Vacations.Add(vacation); 
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // GET api/<VacationController>/5
        [HttpGet]
        [Route("ChangeStatus/{VacationId}/{StatusId}")]
        public IActionResult ChangeStatus(int VacationId,int StatusId)
        { 

            var vacation = context.Vacations.Where(j => j.Id == VacationId).FirstOrDefault();
                    if (vacation != null)
                    {
                        vacation.StatusId = StatusId;
                        vacation.UpdatedDate = DateTime.UtcNow;

                    }
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<VacationController>/5
        [HttpPut]
        [Route("update/{VacationId}")]
        public IActionResult Put(int VacationId, VacationRequest vacationRequest)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var vacation = context.Vacations.Where(j => j.Id == VacationId).FirstOrDefault();
            if (vacation != null)
            {
                vacation.FromDate = vacationRequest.FromDate;
                vacation.ToDate = vacationRequest.ToDate;
                vacation.EmployeeId = vacationRequest.EmployeeId;
                vacation.EmployeeReplaceId = vacationRequest.EmployeeReplaceId;
                vacation.Description = vacationRequest.Description;
                vacation.VacationTypeId = vacationRequest.VacationTypeId;
               // vacation.StatusId = vacationRequest.StatusId;
                vacation.UpdatedDate = DateTime.UtcNow;

            }
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }
    }
}
