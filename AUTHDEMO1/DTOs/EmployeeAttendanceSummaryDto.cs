namespace AUTHDEMO1.DTOs
{
    public class EmployeeAttendanceSummaryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Status { get; set; } = "Absent";
        public string? LeaveType { get; set; }

        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }

        public LeaveBalanceDto LeaveBalance { get; set; } = new LeaveBalanceDto();
    }
}
