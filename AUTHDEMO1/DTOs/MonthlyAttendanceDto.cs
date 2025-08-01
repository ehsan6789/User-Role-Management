namespace AUTHDEMO1.DTOs
{
    public class MonthlyAttendanceDto
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public int TotalDays { get; set; }
        public int Present { get; set; }
        public int Absent { get; set; }
        public int Late { get; set; }
        public int LeavesTaken { get; set; }
    }
}
