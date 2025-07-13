using System.ComponentModel.DataAnnotations.Schema;
using AUTHDEMO1.Models;

public class Employee
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
    public bool IsDeleted { get; set; } = false;
    public DateTime? DeletedAt { get; set; }
    public DateTime DateOfJoining { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }

    // Leave balances
    public int AnnualLeaveBalance { get; set; } = 12;
    public int SickLeaveBalance { get; set; } = 8;
    public int CasualLeaveBalance { get; set; } = 5;

    // Foreign keys
    public int DepartmentId { get; set; }
    public EmployeeStatus Status { get; set; }

    // Navigation properties
    public Department Department { get; set; }
    public ICollection<LeaveRequest> LeaveRequests { get; set; } 
    public ICollection<Attendance> AttendanceRecords { get; set; }
    public ICollection<BankAccount> BankAccounts { get; set; }
}
