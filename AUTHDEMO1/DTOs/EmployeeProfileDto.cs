namespace AUTHDEMO1.DTOs
{
    public class EmployeeProfileDto
    {
        public int Id { get; set; }                // Add this line ✅
        public string Name { get; set; }
        public string Email { get; set; }

        public List<AttendanceRecordDto> AttendanceHistory { get; set; }
        public List<LeaveRecordDto> LeaveHistory { get; set; }
    }
}
