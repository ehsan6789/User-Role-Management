using AUTHDEMO1.DTOs;

namespace AUTHDEMO1.Repositories
{
    public interface IReportRepository
    {
        Task<List<MonthlyAttendanceDto>> GetMonthlyAttendanceReportAsync(int year, int month);
    }
}
