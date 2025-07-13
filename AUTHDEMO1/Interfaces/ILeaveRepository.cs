using AUTHDEMO1.DTOs;
using AUTHDEMO1.Models;

namespace AUTHDEMO1.Interfaces
{
    public interface ILeaveRepository
    {
        Task<bool> ApplyLeaveAsync(CreateLeaveRequestDto leaveDto);
        Task<bool> UpdateLeaveStatusAsync(int leaveRequestId, string status); // NEW
        Task<object> GetLeaveBalanceAsync(int employeeId);
        Task<IEnumerable<LeaveRequest>> GetLeaveHistoryAsync(int employeeId);
        Task<IEnumerable<LeaveRequest>> GetPendingLeaveRequestsAsync(); // NEW
    }
}
