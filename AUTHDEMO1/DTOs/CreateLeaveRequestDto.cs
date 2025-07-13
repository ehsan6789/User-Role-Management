namespace AUTHDEMO1.DTOs
{
    public class CreateLeaveRequestDto
    {
        public int EmployeeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string LeaveType { get; set; }
        public string Reason { get; set; }
    }
}
