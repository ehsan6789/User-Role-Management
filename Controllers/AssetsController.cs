using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AUTHDEMO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetsController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _assetService.GetAllAssetsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _assetService.GetAssetByIdAsync(id));
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAssetDto dto)
        {
            try
            {
                await _assetService.AddAssetAsync(dto); // ✅ Correct method
                return Ok(new { message = "Asset created successfully" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAssetDto dto)
        {
            if (dto.Id != id)
                return BadRequest("ID mismatch between route and body");

            await _assetService.UpdateAssetAsync(dto);
            return Ok(new { message = "Asset updated successfully" });
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _assetService.DeleteAssetAsync(id);
            return Ok(new { message = "Asset deleted successfully" });
        }

        [HttpGet("check-serial")]
        public async Task<IActionResult> CheckSerialNumber([FromQuery] string serialNumber)
        {
            if (string.IsNullOrWhiteSpace(serialNumber))
                return BadRequest("Serial number is required");

            var exists = await _assetService.SerialNumberExistsAsync(serialNumber);
            return Ok(exists);
        }



    }
}
