namespace AUTHDEMO1.DTOs
{
    public class EmployeeAttendanceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; } // Present / Absent / On Leave
        public string? LeaveType { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public LeaveSummaryDto LeaveBalance { get; set; }
    }

    public class LeaveSummaryDto
    {
        public int Sick { get; set; }
        public int Casual { get; set; }
        public int Annual { get; set; }
    }

    public class EmployeeDetailDto
    {
        public string Name { get; set; }
      
        public string Email { get; set; }

        public List<AttendanceRecordDto> AttendanceHistory { get; set; }
        public List<LeaveRecordDto> LeaveHistory { get; set; }
    }

    public class AttendanceRecordDto
    {
        public string Date { get; set; }
        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }
    }

    public class LeaveRecordDto
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
    }
}
