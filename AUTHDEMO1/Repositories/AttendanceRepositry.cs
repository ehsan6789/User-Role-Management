using AUTHDEMO1.Data;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using Microsoft.EntityFrameworkCore;

namespace AUTHDEMO1.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly AppDbContext _context;

        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckInAsync(int employeeId, DateTime date)
        {
            var dateOnly = date.Date;

            var existing = await _context.Attendances
                .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.Date == dateOnly);

            if (existing != null) return false;

            var attendance = new Attendance
            {
                EmployeeId = employeeId,
                Date = dateOnly,
                CheckInTime = DateTime.Now,
                IsPresent = true
            };

            await _context.Attendances.AddAsync(attendance);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CheckOutAsync(int employeeId, DateTime date)
        {
            var dateOnly = date.Date;

            var existing = await _context.Attendances
                .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && x.Date == dateOnly);

            if (existing == null) return false;

            existing.CheckOutTime = DateTime.Now;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Attendance>> GetAttendanceRangeAsync(int employeeId, DateTime from, DateTime to)
        {
            var fromDate = from.Date;
            var toDate = to.Date;

            return await _context.Attendances
                .Where(x => x.EmployeeId == employeeId && x.Date >= fromDate && x.Date <= toDate)
                .ToListAsync();
        }
        public async Task<List<LeaveTypeBalanceDto>> GetLeaveBalanceAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null) return new List<LeaveTypeBalanceDto>();

            var approvedLeaves = await _context.LeaveRequests
                .Where(l => l.EmployeeId == employeeId && l.Status == "Approved")
                .ToListAsync();

            int CountUsed(string type) =>
                approvedLeaves.Where(l => l.LeaveType == type)
                              .Sum(l => (l.ToDate - l.FromDate).Days + 1);

            return new List<LeaveTypeBalanceDto>
    {
        new() {
            LeaveType = "Annual",
            UsedDays = CountUsed("Annual"),
            TotalDays = CountUsed("Annual") + employee.AnnualLeaveBalance
        },
        new() {
            LeaveType = "Sick",
            UsedDays = CountUsed("Sick"),
            TotalDays = CountUsed("Sick") + employee.SickLeaveBalance
        },
        new() {
            LeaveType = "Casual",
            UsedDays = CountUsed("Casual"),
            TotalDays = CountUsed("Casual") + employee.CasualLeaveBalance
              }
         };
            }
        public async Task<List<EmployeeAttendanceSummaryDto>> GetDailySummaryAsync(DateTime date)
        {
            var employees = await _context.Employees.ToListAsync();
            var dateOnly = date.Date;

            var attendances = await _context.Attendances
                .Where(a => a.Date == dateOnly)
                .ToListAsync();

            var leaveRequests = await _context.LeaveRequests
                .Where(l => l.FromDate <= dateOnly && l.ToDate >= dateOnly && l.Status == "Approved")
                .ToListAsync();

            var result = new List<EmployeeAttendanceSummaryDto>();

            foreach (var emp in employees)
            {
                var attendance = attendances.FirstOrDefault(a => a.EmployeeId == emp.Id);
                var leave = leaveRequests.FirstOrDefault(l => l.EmployeeId == emp.Id);

                string status;
                string? leaveType = null;

                if (attendance != null)
                {
                    status = "Present";
                }
                else if (leave != null)
                {
                    status = "On Leave";
                    leaveType = leave.LeaveType;
                }
                else
                {
                    status = "Absent";
                }

                result.Add(new EmployeeAttendanceSummaryDto
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Email = emp.Email,
                    Status = status,
                    LeaveType = leaveType,
                    CheckIn = attendance?.CheckInTime,
                    CheckOut = attendance?.CheckOutTime,
                    LeaveBalance = new LeaveBalanceDto
                    {
                        Sick = emp.SickLeaveBalance,
                        Casual = emp.CasualLeaveBalance,
                        Annual = emp.AnnualLeaveBalance
                    }
                });
            }

            return result;
        }
        public async Task<bool> CheckInExistsAsync(int employeeId, DateTime date)
        {
            var dateOnly = date.Date;
            return await _context.Attendances.AnyAsync(x => x.EmployeeId == employeeId && x.Date == dateOnly);
        }
        




    }
}
