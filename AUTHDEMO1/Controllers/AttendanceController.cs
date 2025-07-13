
using AUTHDEMO1.Data;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AUTHDEMO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _repo;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepo;
        private readonly AppDbContext _context;
        public AttendanceController(IAttendanceRepository repo, IMapper mapper, IEmployeeRepository employeeRepo, AppDbContext context)
        {
            _repo = repo;
            _mapper = mapper;
            _employeeRepo = employeeRepo;
            _context = context;
        }

        [HttpPost("checkin")]
        public async Task<IActionResult> CheckIn([FromBody] AttendanceDto dto)
        {
            var result = await _repo.CheckInAsync(dto.EmployeeId, dto.Date);
            return Ok(result);
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> CheckOut([FromBody] AttendanceDto dto)
        {
            var result = await _repo.CheckOutAsync(dto.EmployeeId, dto.Date);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendance([FromQuery] int employeeId, DateTime fromDate, DateTime toDate)
        {
            var records = await _repo.GetAttendanceRangeAsync(employeeId, fromDate, toDate);
            return Ok(_mapper.Map<IEnumerable<AttendanceDto>>(records));
        }
        [HttpGet("leave-balance/{employeeId}")]
        public async Task<IActionResult> GetLeaveBalance(int employeeId)
        {
            var result = await _repo.GetLeaveBalanceAsync(employeeId);
            return Ok(result);
        }
        [HttpGet("date-summary")]
        public async Task<IActionResult> GetDailySummary([FromQuery] DateTime date)
        {
            var summary = await _repo.GetDailySummaryAsync(date);
            return Ok(summary);
        }
        [HttpGet("exists")]
        public async Task<IActionResult> CheckInExists([FromQuery] int employeeId, [FromQuery] DateTime date)
        {
            var exists = await _repo.CheckInExistsAsync(employeeId, date);
            return Ok(exists);
        }

     

        [HttpGet("details/{employeeId}")]
        public async Task<IActionResult> GetEmployeeAttendanceDetail(int employeeId)
        {
            var result = await _employeeRepo.GetEmployeeAttendanceDetailAsync(employeeId);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpPost("bulk")]
        public async Task<IActionResult> SaveBulkAttendance([FromBody] List<AttendanceSubmitDto> records)
        {
            foreach (var record in records)
            {
                var attendance = new Attendance
                {
                    EmployeeId = record.EmployeeId,
                    Date = record.Date.Date,
                    Status = Enum.TryParse<AttendanceStatus>(record.Status, true, out var status)
                             ? status
                             : AttendanceStatus.Absent,
                    CheckInTime = !string.IsNullOrWhiteSpace(record.CheckIn)
                                  ? DateTime.Parse(record.CheckIn)
                                  : null,
                    CheckOutTime = !string.IsNullOrWhiteSpace(record.CheckOut)
                                  ? DateTime.Parse(record.CheckOut)
                                  : null,
                    LeaveType = record.LeaveType,
                    IsPresent = record.Status.ToLower() == "present"
                };

                _context.Attendances.Add(attendance);
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Attendance saved successfully." });
        }


    }
}
