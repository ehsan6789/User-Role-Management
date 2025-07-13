using AUTHDEMO1.Data;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AUTHDEMO1.Repositories
{
    public class LeaveRepository : ILeaveRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LeaveRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ApplyLeaveAsync(CreateLeaveRequestDto dto)
        {
            var leave = _mapper.Map<LeaveRequest>(dto);
            leave.Status = "Pending";
            await _context.LeaveRequests.AddAsync(leave);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateLeaveStatusAsync(int leaveRequestId, string status)
        {
            var leave = await _context.LeaveRequests.Include(l => l.Employee)
                                                    .FirstOrDefaultAsync(l => l.Id == leaveRequestId);
            if (leave == null) return false;

            leave.Status = status;

            if (status == "Approved")
            {
                var days = (leave.ToDate - leave.FromDate).Days + 1;

                var employee = leave.Employee;

                switch (leave.LeaveType)
                {
                    case "Annual":
                        employee.AnnualLeaveBalance -= days;
                        break;
                    case "Sick":
                        employee.SickLeaveBalance -= days;
                        break;
                    case "Casual":
                        employee.CasualLeaveBalance -= days;
                        break;
                }
            }

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<IEnumerable<LeaveRequest>> GetLeaveHistoryAsync(int employeeId)
        {
            return await _context.LeaveRequests
                .Include(l => l.Employee) 
                .Where(l => l.EmployeeId == employeeId)
                .ToListAsync();
        }


        public async Task<IEnumerable<LeaveRequest>> GetPendingLeaveRequestsAsync()
        {
            return await _context.LeaveRequests
                .Include(l => l.Employee)
                .Where(l => l.Status == "Pending")
                .ToListAsync();
        }

        public async Task<object> GetLeaveBalanceAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null) return null;

            var approvedLeaves = await _context.LeaveRequests
                .Where(l => l.EmployeeId == employeeId && l.Status == "Approved")
                .ToListAsync();

            int annualUsed = approvedLeaves
                .Where(l => l.LeaveType == "Annual")
                .Sum(l => (l.ToDate - l.FromDate).Days + 1);

            int sickUsed = approvedLeaves
                .Where(l => l.LeaveType == "Sick")
                .Sum(l => (l.ToDate - l.FromDate).Days + 1);

            int casualUsed = approvedLeaves
                .Where(l => l.LeaveType == "Casual")
                .Sum(l => (l.ToDate - l.FromDate).Days + 1);

            return new
            {
                annualLeaveUsed = annualUsed,
                annualLeaveBalance = 12 - annualUsed,
                annualLeaveTotal = 12,

                sickLeaveUsed = sickUsed,
                sickLeaveBalance = 8 - sickUsed,
                sickLeaveTotal = 8,

                casualLeaveUsed = casualUsed,
                casualLeaveBalance = 5 - casualUsed,
                casualLeaveTotal = 5
            };
        }



    }
}
