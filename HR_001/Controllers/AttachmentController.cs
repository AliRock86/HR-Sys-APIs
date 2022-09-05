using HR_001.Entities;
using HR_001.Requests;
using HR_001.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        UploadService Add = new UploadService();
        // GET: api/<AttachmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AttachmentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }    

        [HttpPost, DisableRequestSizeLimit]
        //[Route("add/{EmpId}/{TypeId}/{Description}")]
        //public async Task<IActionResult> Post(int EmpId, int TypeId, string Description)
        //{
        //    try
        //    {
        //        var formCollection = await Request.ReadFormAsync();
        //        var file = formCollection.Files.First();
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var UrlPath = Path.Combine(folderName, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            Add.AddAttachData(EmpId, TypeId, Description, UrlPath);
        //            return StatusCode(StatusCodes.Status200OK, new { status = true, message = UrlPath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}

        // PUT api/<EmpAttachmentController>/5
        [HttpPut]
        [Route("update/{AttId}")]
        public IActionResult Put(int AttId, AttachmentRequest attachmentRequest)
        {

            if (!ModelState.IsValid)
            {

                return BadRequest();
            }
            if (AttId != null)
            {

                var attachment = context.Attachments.Where(a => a.Id == 1).First();

                if (attachment != null)
                {
                    attachment.AttachmentTypeId = attachmentRequest.AttachmentTypeId;
                    attachment.EmployeeId = attachmentRequest.EmployeeId;
                    attachment.AttachmentUrl = attachmentRequest.AttachmentUrl;  
                    attachment.Description = attachmentRequest.Description;
                    attachment.UpdatedDate = DateTime.UtcNow;

                };
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { status = true, message = "done" });
            }
            return BadRequest();
        }

        // DELETE api/<AttachmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
