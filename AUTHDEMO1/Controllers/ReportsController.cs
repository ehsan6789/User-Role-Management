using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("monthly-attendance")]
    public async Task<IActionResult> GetMonthlyAttendance([FromQuery] string month)
    {
        if (string.IsNullOrEmpty(month)) return BadRequest("Month is required");

        if (!DateTime.TryParse(month + "-01", out var parsedDate))
            return BadRequest("Invalid month format");

        var result = await _reportService.GetMonthlyAttendanceReportAsync(parsedDate.Year, parsedDate.Month);
        return Ok(result);
    }
}

