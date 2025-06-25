using Microsoft.AspNetCore.Mvc;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Services;

namespace AUTHDEMO1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetAssignmentsController : ControllerBase
    {
        private readonly IAssetAssignmentService _service;

        public AssetAssignmentsController(IAssetAssignmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assignments = await _service.GetAllAssignmentsAsync();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var assignment = await _service.GetAssignmentByIdAsync(id);
            return assignment == null ? NotFound() : Ok(assignment);
        }

        [HttpPost]
        public async Task<IActionResult> Assign(AssignAssetDto dto)
        {
            var result = await _service.AssignAssetAsync(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAssetAssignmentDto dto)
        {
            var result = await _service.UpdateAssignmentAsync(id, dto);
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAssignmentAsync(id);
            return NoContent();
        }
    }
}
