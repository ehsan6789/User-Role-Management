using AUTHDEMO1.DTOs;
using AUTHDEMO1.Models;

namespace AUTHDEMO1.Interfaces
{
    public interface IAttendanceRepository
    {
        Task<bool> CheckInAsync(int employeeId, DateTime date);
        Task<bool> CheckOutAsync(int employeeId, DateTime date);
        Task<IEnumerable<Attendance>> GetAttendanceRangeAsync(int employeeId, DateTime from, DateTime to);
        Task<List<LeaveTypeBalanceDto>> GetLeaveBalanceAsync(int employeeId);
        Task<List<EmployeeAttendanceSummaryDto>> GetDailySummaryAsync(DateTime date);
        Task<bool> CheckInExistsAsync(int employeeId, DateTime date);




    }
}
