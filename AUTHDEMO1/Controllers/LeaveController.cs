using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AUTHDEMO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly ILeaveRepository _repo;
        private readonly IMapper _mapper;

        public LeaveController(ILeaveRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyLeave([FromBody] CreateLeaveRequestDto dto)
        {
            var result = await _repo.ApplyLeaveAsync(dto);
            return Ok(result);
        }

        [HttpPost("update-status")]
        public async Task<IActionResult> UpdateLeaveStatus([FromBody] UpdateLeaveStatusDto dto)
        {
            var result = await _repo.UpdateLeaveStatusAsync(dto.LeaveRequestId, dto.Status);
            if (!result)
                return BadRequest("Invalid leave request ID or status.");

            return Ok(new { message = "Leave status updated" });
        }

        [HttpGet("balance/{employeeId}")]
        public async Task<IActionResult> GetBalance(int employeeId)
        {
            var result = await _repo.GetLeaveBalanceAsync(employeeId);
            return Ok(result);
        }

        [HttpGet("history/{employeeId}")]
        public async Task<IActionResult> GetHistory(int employeeId)
        {
            var history = await _repo.GetLeaveHistoryAsync(employeeId);
            return Ok(_mapper.Map<IEnumerable<LeaveRequestDto>>(history));
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingLeaves()
        {
            var pending = await _repo.GetPendingLeaveRequestsAsync();
            return Ok(_mapper.Map<IEnumerable<LeaveRequestDto>>(pending));
        }
    }
}
