namespace AUTHDEMO1.DTOs
{
    public class LeaveRequestDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string LeaveType { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public int AnnualLeaveBalance { get; set; }
        public int SickLeaveBalance { get; set; }
        public int CasualLeaveBalance { get; set; }
    }
}
