using AUTHDEMO1.DTOs;

public interface IReportService
{
    Task<List<MonthlyAttendanceDto>> GetMonthlyAttendanceReportAsync(int year, int month);
}


