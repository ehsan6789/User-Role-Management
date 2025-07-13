namespace AUTHDEMO1.DTOs
{
    public class LeaveBalanceDto
    {
        public string LeaveType { get; set; }
        public int TotalDays { get; set; }
        public int UsedDays { get; set; }
        public int RemainingDays => TotalDays - UsedDays;
        public int Balance { get; set; }
        public int Sick { get; set; }
        public int Casual { get; set; }
        public int Annual { get; set; }

    }
}
