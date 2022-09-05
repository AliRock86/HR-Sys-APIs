using HR_001.Entities;
using HR_001.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpAddressController : ControllerBase
    {
        HrDbContext context = new HrDbContext();

        // GET api/<EmpAddressController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmpAddressController>
        [HttpPost]
        [Route("add")]
        public IActionResult Post(EmpAddressRequest empAddressRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var address = new Address
            {
                District = empAddressRequest.District,
                HouseNumber = empAddressRequest.HouseNumber,
                RCN = empAddressRequest.RCN,
                Description = empAddressRequest.Description,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                EmployeeId = empAddressRequest.EmployeeId,
                RegionId = empAddressRequest.RegionId,
                StreetNumber = empAddressRequest.StreetNumber,

            };

            context.Addresses.Add(address);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<EmpAddressController>/5
        [HttpPut]
        [Route("update/{AddId}")]
        public IActionResult Put(int AddId, EmpAddressRequest empAddressRequest)
        {
           
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            if(AddId != null) { 

            var address = context.Addresses.Where(a => a.Id == 1).First();

            if (address != null)
            {
                address.District = empAddressRequest.District;
                address.HouseNumber = empAddressRequest.HouseNumber;
                address.RCN = empAddressRequest.RCN;
                address.Description = empAddressRequest.Description;
                address.CreatedDate = DateTime.UtcNow;
                address.UpdatedDate = DateTime.UtcNow;
                address.EmployeeId = empAddressRequest.EmployeeId;
                address.RegionId = empAddressRequest.RegionId;
                address.StreetNumber = empAddressRequest.StreetNumber;

            };
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
            }
            return BadRequest();
        }

        // DELETE api/<EmpAddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
