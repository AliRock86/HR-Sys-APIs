using HR_001.Entities;
using HR_001.Requests;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ContactController>
        [HttpPost]
        [Route("add")]
        public IActionResult Post(ContactRequest contactRequest)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest();
            }

            var contact = new Contact
            {
                EmployeeId = contactRequest.EmployeeId,
                Email = contactRequest.Email,
                Phone = contactRequest.Phone,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            context.Contacts.Add(contact);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
        }

        // PUT api/<EmpBranchController>/5
        [HttpPut]
        [Route("update/{contactId}")]
        public IActionResult Put(int contactId, ContactRequest contactRequest)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            if (contactId != null)
            {

                var contact = context.Contacts.Where(a => a.Id == contactId).First();

                if (contact != null)
                {
                    contact.EmployeeId = contactRequest.EmployeeId;
                    contact.Email = contactRequest.Email;
                    contact.Phone = contactRequest.Phone;
                    contact.UpdatedDate = DateTime.UtcNow;


                };
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
            }
            return BadRequest();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
