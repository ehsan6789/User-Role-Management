
using AUTHDEMO1.Helpers;
using AUTHDEMO1.Models;
using Microsoft.AspNetCore.Mvc;

namespace AUTHDEMO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupsController : ControllerBase
    {
        [HttpGet("employee-statuses")]
        public IActionResult GetEmployeeStatuses()
        {
            var statuses = EnumHelper.GetEnumAsList<EmployeeStatus>();
            return Ok(statuses);
        }
    }
}
