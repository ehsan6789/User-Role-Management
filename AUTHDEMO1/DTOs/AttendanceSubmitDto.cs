namespace AUTHDEMO1.DTOs
{
    public class AttendanceSubmitDto
    {
        public int EmployeeId { get; set; }
        public string Status { get; set; }  // "present", "absent", "leave"
        public DateTime Date { get; set; }
        public string? CheckIn { get; set; }
        public string? CheckOut { get; set; }
        public string? LeaveType { get; set; }
    }
}
