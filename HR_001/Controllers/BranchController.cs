using HR_001.Entities;
using HR_001.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<BranchController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BranchController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BranchController>
        [HttpPost]
        [Route("add")]
        public IActionResult Post(BranchRequest branchRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var branch = new Branch
            {
                BranchTypeId = branchRequest.BranchTypeId,
                EmployeeId = branchRequest.EmployeeId,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            context.Branches.Add(branch);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<EmpBranchController>/5
        [HttpPut]
        [Route("update/{BrId}")]
        public IActionResult Put(int BrId, BranchRequest BranchRequest)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            if (BrId != null)
            {

                var branch = context.Branches.Where(a => a.Id == 1).First();

                if (branch != null)
                {
                    branch.BranchTypeId = BranchRequest.BranchTypeId;
                    branch.EmployeeId = BranchRequest.EmployeeId;
                    branch.UpdatedDate = DateTime.UtcNow;

                };
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
            }
            return BadRequest();
        }

        // DELETE api/<BranchController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
