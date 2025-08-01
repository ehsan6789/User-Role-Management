using AUTHDEMO1.Data;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Models;
using Microsoft.EntityFrameworkCore;

namespace AUTHDEMO1.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public ReportRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<List<MonthlyAttendanceDto>> GetMonthlyAttendanceReportAsync(int year, int month)
        {
          
            string? thresholdString = _configuration["AttendanceSettings:LateThreshold"];
            TimeSpan lateThreshold = TimeSpan.TryParse(thresholdString, out var parsed)
                ? parsed
                : new TimeSpan(15, 30, 0);

            var employees = await _context.Employees
                .Include(e => e.Department)
                .Where(e => e.Status == EmployeeStatus.Active)
                .ToListAsync();

            var attendances = await _context.Attendances
                .Where(a => a.Date.Year == year && a.Date.Month == month)
                .ToListAsync();

            var report = employees.Select(emp =>
            {
                var empAttendance = attendances.Where(a => a.EmployeeId == emp.Id).ToList();

                return new MonthlyAttendanceDto
                {
                    EmployeeId = emp.Id,
                    Name = emp.Name,
                    Email = emp.Email,
                    Department = emp.Department?.Name,
                    TotalDays = DateTime.DaysInMonth(year, month),
                    Present = empAttendance.Count(a => a.Status == AttendanceStatus.Present),
                    Absent = empAttendance.Count(a => a.Status == AttendanceStatus.Absent),

                  
                    Late = empAttendance.Count(a =>
                        a.Status == AttendanceStatus.Present &&
                        a.CheckInTime.HasValue &&
                        a.CheckInTime.Value.TimeOfDay > lateThreshold
                    ),

                    LeavesTaken = empAttendance.Count(a => a.Status == AttendanceStatus.Leave)
                };
            }).ToList();

            return report;
        }
    }
}

