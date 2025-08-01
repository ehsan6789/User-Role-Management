using AUTHDEMO1.DTOs;
using AUTHDEMO1.Repositories;

namespace AUTHDEMO1.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<List<MonthlyAttendanceDto>> GetMonthlyAttendanceReportAsync(int year, int month)
        {
            return await _reportRepository.GetMonthlyAttendanceReportAsync(year, month);
        }
    }

}
