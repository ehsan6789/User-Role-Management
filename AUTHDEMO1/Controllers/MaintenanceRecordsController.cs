using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AUTHDEMO1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenanceRecordsController : ControllerBase
    {
        private readonly IMaintenanceRecordService _service;

        public MaintenanceRecordsController(IMaintenanceRecordService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var records = await _service.GetAllMaintenanceRecordsAsync();
            return Ok(records);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var record = await _service.GetMaintenanceRecordByIdAsync(id);
            return record == null ? NotFound() : Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMaintenanceRecordDto dto)
        {
            var result = await _service.CreateMaintenanceRecordAsync(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateMaintenanceRecordDto dto)
        {
            var result = await _service.UpdateMaintenanceRecordAsync(id, dto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteMaintenanceRecordAsync(id);
            return NoContent();
        }
    }
}
