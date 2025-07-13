using AUTHDEMO1.DTOs;

namespace AUTHDEMO1.Interfaces
{
    public interface IEmployeeReportRepository
    {
        Task<List<EmployeeAttendanceDto>> GetAttendanceSummaryAsync();
        Task<EmployeeDetailDto> GetEmployeeDetailAsync(int employeeId);
    }
}
