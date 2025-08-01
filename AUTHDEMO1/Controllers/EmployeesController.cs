using System.Security.Claims;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AUTHDEMO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public EmployeesController(
            IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await _employeeRepository.GetEmployeeWithBankAccountsAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpGet("department/{departmentId}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesByDepartment(int departmentId)
        {
            var employees = await _employeeRepository.GetEmployeesByDepartmentAsync(departmentId);
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployeesByStatus(string status)
        {
            if (!Enum.TryParse<EmployeeStatus>(status, out var employeeStatus))
                return BadRequest("Invalid status value");

            var employees = await _employeeRepository.GetEmployeesByStatusAsync(employeeStatus);
            return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployeeDto createEmployeeDto)
        {
            var department = await _departmentRepository.GetByIdAsync(createEmployeeDto.DepartmentId);
            if (department == null)
                return BadRequest("Invalid department ID");

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "TestUser123";

            var employee = _mapper.Map<Employee>(createEmployeeDto);
            employee.CreatedAt = DateTime.UtcNow;
            employee.CreatedBy = userId;


            if (createEmployeeDto.BankAccounts != null && createEmployeeDto.BankAccounts.Any())
            {
                employee.BankAccounts = createEmployeeDto.BankAccounts.Select(dto => new BankAccount
                {
                    AccountTitle = dto.AccountTitle,
                    BankName = dto.BankName,
                    AccountNumber = dto.AccountNumber,
                    IBAN = dto.IBAN,
                    Reference = dto.Reference,
                    IsPrimary = dto.IsPrimary
                }).ToList();
            }

            await _employeeRepository.AddAsync(employee);

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, _mapper.Map<EmployeeDto>(employee));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await _employeeRepository.GetEmployeeWithBankAccountsAsync(id);
            if (employee == null)
                return NotFound();

            var department = await _departmentRepository.GetByIdAsync(updateEmployeeDto.DepartmentId);
            if (department == null)
                return BadRequest("Invalid department ID");

            _mapper.Map(updateEmployeeDto, employee);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "TestUser123";
            employee.UpdatedAt = DateTime.UtcNow;
            employee.UpdatedBy = userId;

      
            if (updateEmployeeDto.BankAccounts != null)
            {
                employee.BankAccounts.Clear(); 
                foreach (var dto in updateEmployeeDto.BankAccounts)
                {
                    employee.BankAccounts.Add(new BankAccount
                    {
                        AccountTitle = dto.AccountTitle,
                        BankName = dto.BankName,
                        AccountNumber = dto.AccountNumber,
                        IBAN = dto.IBAN,
                        Reference = dto.Reference,
                        IsPrimary = dto.IsPrimary
                    });
                }
            }

            await _employeeRepository.UpdateAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            employee.IsDeleted = true;
            employee.DeletedAt = DateTime.UtcNow;
            await _employeeRepository.UpdateAsync(employee);

            return NoContent();
        }
        [HttpGet("{id}/leave-summary")]
        public async Task<ActionResult<EmployeeLeaveSummaryDto>> GetLeaveSummary(int id)
        {
            var summary = await _employeeRepository.GetLeaveSummaryAsync(id);
            return Ok(summary);
        }
        [HttpGet("{id}/asset-assignments")]
        public async Task<ActionResult<List<AssetAssignmentDto>>> GetAssetAssignments(int id)
        {
            var assignments = await _employeeRepository.GetEmployeeAssetAssignmentsAsync(id);
            return Ok(assignments);
        }


    }
}
