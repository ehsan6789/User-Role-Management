using AUTHDEMO1.Data;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AUTHDEMO1.Repositories
{
    public class EmployeeReportRepository : IEmployeeReportRepository
    {
        private readonly AppDbContext _context;

        public EmployeeReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeAttendanceDto>> GetAttendanceSummaryAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            var result = new List<EmployeeAttendanceDto>();

            foreach (var emp in employees)
            {
                var lastAttendance = await _context.Attendances
                    .Where(a => a.EmployeeId == emp.Id)
                    .OrderByDescending(a => a.Date)
                    .FirstOrDefaultAsync();

                var status = "Absent";
                if (lastAttendance != null)
                {
                    status = lastAttendance.Status.ToString();
                }

                result.Add(new EmployeeAttendanceDto
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Email = emp.Email,
                    Status = status,
                    CheckIn = lastAttendance?.CheckInTime,
                    CheckOut = lastAttendance?.CheckOutTime,
                    LeaveType = status == "Leave" ? lastAttendance?.LeaveType : null,
                    LeaveBalance = new LeaveSummaryDto
                    {
                        Sick = emp.SickLeaveBalance,
                        Casual = emp.CasualLeaveBalance,
                        Annual = emp.AnnualLeaveBalance
                    }
                });
            }

            return result;
        }

        public async Task<EmployeeDetailDto> GetEmployeeDetailAsync(int employeeId)
        {
            var emp = await _context.Employees.FindAsync(employeeId);
            if (emp == null) throw new Exception("Employee not found");

            var attendanceHistory = await _context.Attendances
                .Where(a => a.EmployeeId == employeeId)
                .OrderByDescending(a => a.Date)
               .Select(a => new AttendanceRecordDto
               {
                   Date = a.Date.ToString("yyyy-MM-dd"),
                   CheckIn = a.CheckInTime != null ? a.CheckInTime.Value.ToString("hh:mm tt") : null,
                   CheckOut = a.CheckOutTime != null ? a.CheckOutTime.Value.ToString("hh:mm tt") : null
               }).ToListAsync();

            var leaveHistory = await _context.LeaveRequests
                .Where(l => l.EmployeeId == employeeId)
                .OrderByDescending(l => l.FromDate)
                .Select(l => new LeaveRecordDto
                {
                    FromDate = l.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = l.ToDate.ToString("yyyy-MM-dd"),
                    Type = l.LeaveType,
                    Status = l.Status
                }).ToListAsync();

            return new EmployeeDetailDto
            {
                Name = emp.Name,
                Email = emp.Email,
                AttendanceHistory = attendanceHistory,
                LeaveHistory = leaveHistory
            };
        }
    }
}
