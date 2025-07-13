
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AUTHDEMO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountsController : ControllerBase
    {
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public BankAccountsController(
            IBankAccountRepository bankAccountRepository,
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _bankAccountRepository = bankAccountRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        [HttpGet("employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<BankAccountDto>>> GetBankAccountsByEmployee(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            var bankAccounts = await _bankAccountRepository.GetBankAccountsByEmployeeIdAsync(employeeId);
            return Ok(_mapper.Map<IEnumerable<BankAccountDto>>(bankAccounts));
        }
        [HttpGet("employee/{employeeId}/primary")]
        public async Task<ActionResult<BankAccountDto>> GetPrimaryBankAccount(int employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            var primaryAccount = await _bankAccountRepository.GetPrimaryBankAccountByEmployeeIdAsync(employeeId);
            if (primaryAccount == null)
            {
                return NotFound("No primary bank account found for this employee");
            }
            return Ok(_mapper.Map<BankAccountDto>(primaryAccount));
        }
        [HttpPost]
        public async Task<ActionResult<BankAccountDto>> CreateBankAccount(CreateBankAccountDto createBankAccountDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(createBankAccountDto.EmployeeId);
            if (employee == null)
            {
                return BadRequest("Invalid employee ID");
            }
            var bankAccount = _mapper.Map<BankAccount>(createBankAccountDto);

            // If this is the first account or set as primary, update other accounts
            if (createBankAccountDto.IsPrimary)
            {
                var existingAccounts = await _bankAccountRepository.GetBankAccountsByEmployeeIdAsync(createBankAccountDto.EmployeeId);
                if (existingAccounts.Any())
                {
                    foreach (var account in existingAccounts)
                    {
                        account.IsPrimary = false;
                    }
                }
            }
            await _bankAccountRepository.AddAsync(bankAccount);
            return CreatedAtAction(nameof(GetBankAccount), new { id = bankAccount.Id }, _mapper.Map<BankAccountDto>(bankAccount));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BankAccountDto>> GetBankAccount(int id)
        {
            var bankAccount = await _bankAccountRepository.GetByIdAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BankAccountDto>(bankAccount));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBankAccount(int id, BankAccountDto bankAccountDto)
        {
            if (id != bankAccountDto.Id)
            {
                return BadRequest();
            }
            var bankAccount = await _bankAccountRepository.GetByIdAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }
            // Update bank account
            _mapper.Map(bankAccountDto, bankAccount);

            // If setting as primary, update other accounts
            if (bankAccountDto.IsPrimary)
            {
                await _bankAccountRepository.SetPrimaryBankAccountAsync(bankAccount.EmployeeId, bankAccount.Id);
            }
            else
            {
                await _bankAccountRepository.UpdateAsync(bankAccount);
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankAccount(int id)
        {
            var bankAccount = await _bankAccountRepository.GetByIdAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }
            await _bankAccountRepository.DeleteAsync(id);

            // If the deleted account was primary, set another account as primary if available
            if (bankAccount.IsPrimary)
            {
                var remainingAccounts = await _bankAccountRepository.GetBankAccountsByEmployeeIdAsync(bankAccount.EmployeeId);
                if (remainingAccounts.Any())
                {
                    var firstAccount = remainingAccounts.First();
                    firstAccount.IsPrimary = true;
                    await _bankAccountRepository.UpdateAsync(firstAccount);
                }
            }
            return NoContent();
        }
        [HttpPost("{id}/set-primary")]
        public async Task<IActionResult> SetPrimaryBankAccount(int id)
        {
            var bankAccount = await _bankAccountRepository.GetByIdAsync(id);
            if (bankAccount == null)
            {
                return NotFound();
            }
            await _bankAccountRepository.SetPrimaryBankAccountAsync(bankAccount.EmployeeId, id);
            return NoContent();
        }
    }
}