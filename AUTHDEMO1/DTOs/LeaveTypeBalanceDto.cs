namespace AUTHDEMO1.DTOs
{
    public class LeaveTypeBalanceDto
    {
        public string LeaveType { get; set; }
        public int TotalDays { get; set; }
        public int UsedDays { get; set; }
        public int RemainingDays => TotalDays - UsedDays;
    }
}
