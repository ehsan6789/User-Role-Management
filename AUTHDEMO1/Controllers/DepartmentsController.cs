
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AUTHDEMO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentsController(
            IDepartmentRepository departmentRepository,
            IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<DepartmentDto>>(departments));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<DepartmentDto>(department));
        }
        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> CreateDepartment(DepartmentDto departmentDto)
        {
            // Check if department with same name already exists
            var existingDepartment = await _departmentRepository.GetByNameAsync(departmentDto.Name);
            if (existingDepartment != null)
            {
                return BadRequest("Department with this name already exists");
            }
            var department = _mapper.Map<Department>(departmentDto);
            await _departmentRepository.AddAsync(department);
            return CreatedAtAction(
                nameof(GetDepartment),
                new { id = department.Id },
                _mapper.Map<DepartmentDto>(department));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentDto departmentDto)
        {
            if (id != departmentDto.Id)
            {
                return BadRequest();
            }
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            // Check if new name conflicts with existing department
            if (department.Name != departmentDto.Name)
            {
                var existingDepartment = await _departmentRepository.GetByNameAsync(departmentDto.Name);
                if (existingDepartment != null)
                {
                    return BadRequest("Department with this name already exists");
                }
            }
            _mapper.Map(departmentDto, department);
            await _departmentRepository.UpdateAsync(department);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            await _departmentRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}