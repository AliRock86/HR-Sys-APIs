using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreeController : ControllerBase
    {
        HrDbContext context = new HrDbContext();
        // GET: api/<FreeDataController>
        [HttpGet]
        [Route("getStatusType")]

        public IActionResult GetStatusType()
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.StatusTypes.ToList() });
        }

        // GET api/<FreeDataController>/5
        [HttpGet]
        [Route("getBranchType")]
        public IActionResult GetBranchType()
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.BranchTypes.ToList() });
        }

        // GET api/<FreeDataController>/5
        [HttpGet]
        [Route("getAttachmentType")]
        public IActionResult GetAttachmentType()
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.AttachmentTypes.ToList() });
        }

        // GET api/<FreeDataController>/5
        [HttpGet]
        [Route("getEducationType")]
        public IActionResult GetEducationType()
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.EducationTypes.ToList() });
        }

        // GET api/<FreeDataController>/5
        [HttpGet]
        [Route("getPermissionType")]
        public IActionResult GetPermissionType()
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.PermissionTypes.ToList() });
        }

        // GET api/<FreeDataController>/5
        [HttpGet]
        [Route("getJobType")]
        public IActionResult GetJobType()
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.JobTypes.ToList() });
        }

        // GET api/<FreeDataController>/5
        [HttpGet]
        [Route("getPositionType")]
        public IActionResult GetPositionType()
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.PermissionTypes.ToList() });
        }

        // GET api/<FreeDataController>/5
        [HttpGet]
        [Route("getProvince")]
        public IActionResult GetProvince()
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.Provinces.ToList() });
        }

        // GET api/<FreeDataController>/5
        [HttpGet]
        [Route("getRegion/{ProvinceId}")]
        public IActionResult GetRegion(int ProvinceId)
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.Regions.Where(r => r.ProvinceId == ProvinceId).ToList() });
        }

        // GET api/<FreeDataController>/5
        [HttpGet]
        [Route("getCompanyType")]  
        public IActionResult GetCompanyType()
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.CompanyTypes.ToList() });
        }

        // GET api/<FreeDataController>/5
        [HttpGet]
        [Route("GetVacationType")]
        public IActionResult GetVacationType()
        {
            return StatusCode(StatusCodes.Status200OK, new { status = true, data = context.VacationTypes.ToList() });
        }
    }
}
