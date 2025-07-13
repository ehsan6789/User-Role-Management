namespace AUTHDEMO1.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string LeaveType { get; set; } // Annual, Sick, Casual
        public string Status { get; set; } // Pending, Approved, Rejected
        public string Reason { get; set; }

        public Employee Employee { get; set; }
    }
}
