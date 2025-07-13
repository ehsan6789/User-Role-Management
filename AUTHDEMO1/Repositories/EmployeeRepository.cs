
using AUTHDEMO1.Data;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using Microsoft.EntityFrameworkCore;

namespace AUTHDEMO1.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
        // YE METHOD ADD KIYA - GetAllAsync override
        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Include(e => e.Department)  // Department include kar rahe hain
                .ToListAsync();
        }

        // YE METHOD BHI ADD KIYA - GetByIdAsync override
        public override async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
        {
            return await _context.Employees
                    .Include(e => e.Department)
                .Where(e => e.DepartmentId == departmentId)
                .ToListAsync();
        }


        public async Task<IEnumerable<Employee>> GetEmployeesByStatusAsync(EmployeeStatus status)
        {
            return await _context.Employees
                .Where(e => e.Status == status)
                .Include(e => e.Department)
                .ToListAsync();
        }
        public async Task<Employee> GetEmployeeWithBankAccountsAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.BankAccounts)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<EmployeeLeaveSummaryDto> GetLeaveSummaryAsync(int employeeId)
        {
            int totalAllocated = 20; // Static or can come from DB/config

            int usedLeaves = await _context.LeaveRequests
                .Where(x => x.EmployeeId == employeeId && x.Status == "Approved")
                .SumAsync(x => EF.Functions.DateDiffDay(x.FromDate, x.ToDate) + 1);

            return new EmployeeLeaveSummaryDto
            {
                AllocatedLeaves = totalAllocated,
                UsedLeaves = usedLeaves,
                RemainingLeaves = totalAllocated - usedLeaves
            };
        }
        public async Task<List<AssetAssignmentDto>> GetEmployeeAssetAssignmentsAsync(int employeeId)
        {
            return await _context.AssetAssignments
                .Where(x => x.EmployeeId == employeeId)
                .Include(x => x.Asset)
                .Select(x => new AssetAssignmentDto
                {
                    AssetName = x.Asset.Name,
                    SerialNumber = x.Asset.SerialNumber,
                    AssignedDate = x.AssignedDate,
                    ReturnedDate = x.ReturnedDate
                })
                .ToListAsync();
        }
        public async Task<EmployeeProfileDto> GetEmployeeAttendanceDetailAsync(int employeeId)
        {
            var employee = await _context.Employees
                .Include(e => e.AttendanceRecords)
                .Include(e => e.LeaveRequests)
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null) return null;

            return new EmployeeProfileDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                AttendanceHistory = employee.AttendanceRecords.Select(ar => new AttendanceRecordDto
                {
                    Date = ar.Date.ToString("yyyy-MM-dd"),
                    CheckIn = ar.CheckInTime?.ToString("HH:mm"),
                    CheckOut = ar.CheckOutTime?.ToString("HH:mm")
                }).ToList(),
                LeaveHistory = employee.LeaveRequests.Select(l => new LeaveRecordDto
                {
                    FromDate = l.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = l.ToDate.ToString("yyyy-MM-dd"),
                    Type = l.LeaveType,
                    Status = l.Status
                }).ToList()
            };
        }
    }
}
