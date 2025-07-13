namespace AUTHDEMO1.Models
{
    public class AssignedLeave
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string LeaveType { get; set; } // Annual, Sick, etc.
        public int TotalDays { get; set; }
        public int UsedDays { get; set; }

        public Employee Employee { get; set; }
    }
}
