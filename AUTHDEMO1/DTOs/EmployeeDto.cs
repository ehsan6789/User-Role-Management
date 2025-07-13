namespace AUTHDEMO1.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string EmergencyNo { get; set; }
        public string Education { get; set; }
        public string CNIC { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Experience { get; set; }
        public string Religion { get; set; }
        public string MaritalStatus { get; set; }
        public string Reference { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int AnnualLeaveBalance { get; set; }
        public int SickLeaveBalance { get; set; }
        public int CasualLeaveBalance { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<BankAccountDto> BankAccounts { get; set; }
        public string ApplicationUserId { get; set; }

    }
}
