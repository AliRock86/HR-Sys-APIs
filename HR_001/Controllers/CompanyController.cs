using HR_001.Entities;
using HR_001.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<CompanyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyController>
        [HttpPost]
        [Route("add")]
        public IActionResult Post(CompanyRequest companyRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var company = new Company
            {
                CompanyTypeId = companyRequest.CompanyTypeId,
                CompanyName = companyRequest.CompanyName,
                CompanyNameArb = companyRequest.CompanyNameArb,
                Descriptions = companyRequest.Descriptions,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            context.Companies.Add(company);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<EmpBranchController>/5
        [HttpPut]
        [Route("update/{CompanyId}")]
        public IActionResult Put(int CompanyId, CompanyRequest companyRequest)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            if (CompanyId != null)
            {

                var company = context.Companies.Where(a => a.Id == CompanyId).First();

                if (company != null)
                {
                    company.CompanyTypeId = companyRequest.CompanyTypeId;
                    company.CompanyName = companyRequest.CompanyName;
                    company.CompanyNameArb = companyRequest.CompanyNameArb;
                    company.Descriptions = companyRequest.Descriptions;
                    company.UpdatedDate = DateTime.UtcNow;


                };
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
            }
            return BadRequest();
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
