using AUTHDEMO1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AUTHDEMO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeReportController : ControllerBase
    {
        private readonly IEmployeeReportRepository _repo;

        public EmployeeReportController(IEmployeeReportRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("attendance-leave")]
        public async Task<IActionResult> GetAttendanceSummary()
        {
            var result = await _repo.GetAttendanceSummaryAsync();
            return Ok(result);
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetEmployeeDetail(int id)
        {
            var result = await _repo.GetEmployeeDetailAsync(id);
            return Ok(result);
        }
    }
}
