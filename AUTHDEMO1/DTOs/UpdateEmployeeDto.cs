namespace AUTHDEMO1.DTOs
{
    public class UpdateEmployeeDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string EmergencyNo { get; set; }
        public string Education { get; set; }
        public string Experience { get; set; }
        public string MaritalStatus { get; set; }
        public string Reference { get; set; }
        public int DepartmentId { get; set; }
        public string Status { get; set; }
        public int AnnualLeaveBalance { get; set; }
        public int SickLeaveBalance { get; set; }
        public int CasualLeaveBalance { get; set; }
        public List<BankAccountDto> BankAccounts { get; set; }
    }
}
