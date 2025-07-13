namespace AUTHDEMO1.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public AttendanceStatus Status { get; set; }
        public string? LeaveType { get; set; }

        public bool IsPresent { get; set; }

        public Employee Employee { get; set; }
    }
}
