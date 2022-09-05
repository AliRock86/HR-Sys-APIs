using HR_001.Entities;
using HR_001.Requests;
using HR_001.Responses;
using Microsoft.AspNetCore.Mvc;


namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            var employees = (from employee in context.Employees join status in context.Statuses 
                             on employee.StatusId equals status.StatusId
                             select new
                             {
                                 Id = employee.Id,
                                 Fname = employee.FamilytName,
                                 Sname = employee.SecondName,
                                 Tname = employee.ThirdName,
                                 Lname = employee.LasttName,
                                 FMname = employee.FamilytName,
                                 StatusId = employee.StatusId,
                                 StatusName = status.StatusName,

                             }).ToList();
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = employees}); ;
        }

        [HttpGet]
        [Route("getById/{EmpId}")]

        public IActionResult GetEmployee(int EmpId)
        {
            var employees = (from employee in context.Employees
                             join status in context.Statuses
                             on employee.StatusId equals status.StatusId
                             where employee.Id == EmpId
                             select new
                             {
                                 Id = employee.Id,
                                 Fname = employee.FamilytName,
                                 Sname = employee.SecondName,
                                 Tname = employee.ThirdName,
                                 Lname = employee.LasttName,
                                 FMname = employee.FamilytName,
                                 StatusId = employee.StatusId,
                                 StatusName = status.StatusName,

                             }).ToList();
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = employees }); ;
        } 


        [HttpGet]
        [Route("changeStatus/{EmpId}/{statusId}")]

        public IActionResult StatusChange(int EmpId , int statusId)
        {
            var emp = context.Employees.Where(e => e.Id == EmpId).First();
            if(emp != null)
            {
                emp.StatusId = statusId;
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
            }
            return StatusCode(StatusCodes.Status406NotAcceptable, new { status = false, message = "Employee did not exist" });
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("add")]

        public IActionResult AddEmployee(AddEmployeeRequest employeeRequest)
        {

            if (!ModelState.IsValid)
            {
 
                    return BadRequest();
            }

            var employee = new Employee
            {
                FirstName = employeeRequest.FirstName,
                SecondName = employeeRequest.SecondName,
                ThirdName = employeeRequest.ThirdName,
                LasttName = employeeRequest.LasttName,
                FamilytName = employeeRequest.FamilytName,
                MotherName = employeeRequest.MotherName,
                Gendar = employeeRequest.Gendar,
                MartialState = employeeRequest.MartialState,
                NoOfChildreen = employeeRequest.NoOfChildreen,
                ProvinceId = employeeRequest.ProvinceId,
                NationalId = employeeRequest.NationalId,
                DOB = employeeRequest.DOB,
                PassportId = employeeRequest.PassportId,
                GovernmentId = employeeRequest.GovernmentId,
                StatusId = 1,

            };

            context.Employees.Add(employee);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK,new {status = true , message = "done"});
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        [Route("update/{EmpId}")]

        public IActionResult UpdateEmployee(int EmpId, AddEmployeeRequest employeeRequest)
        {
            var employee = context.Employees.Where(emp => emp.Id == EmpId).First();
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            if(employee != null)
            {
                employee.FirstName = employeeRequest.FirstName;
                employee.SecondName = employeeRequest.SecondName;
                employee.ThirdName = employeeRequest.ThirdName;
                employee.LasttName = employeeRequest.LasttName;
                employee.FamilytName = employeeRequest.FamilytName;
                employee.MotherName = employeeRequest.MotherName;
                employee.Gendar = employeeRequest.Gendar;
                employee.MartialState = employeeRequest.MartialState;
                employee.NoOfChildreen = employeeRequest.NoOfChildreen;
                employee.ProvinceId = employeeRequest.ProvinceId;
                employee.NationalId = employeeRequest.NationalId;
                employee.DOB = employeeRequest.DOB;
                employee.PassportId = employeeRequest.PassportId;
                employee.GovernmentId = employeeRequest.GovernmentId;
                employee.StatusId = 1;

            };
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

       /* // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
