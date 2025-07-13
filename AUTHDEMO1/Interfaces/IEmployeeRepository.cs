using AUTHDEMO1.DTOs;
using AUTHDEMO1.Models;

namespace AUTHDEMO1.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId);
        Task<IEnumerable<Employee>> GetEmployeesByStatusAsync(EmployeeStatus status);
        Task<Employee> GetEmployeeWithBankAccountsAsync(int id);
        Task<EmployeeLeaveSummaryDto> GetLeaveSummaryAsync(int employeeId);
        Task<List<AssetAssignmentDto>> GetEmployeeAssetAssignmentsAsync(int employeeId);

        Task<EmployeeProfileDto> GetEmployeeAttendanceDetailAsync(int employeeId);

        Task SaveChangesAsync();
    }
}
