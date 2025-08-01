using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AUTHDEMO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }

     
 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound(new { Message = "User not found." });

            return Ok(user);
        }

    
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdUser = await _userService.CreateAsync(dto);
            return Ok(new { Message = "User created successfully.", User = createdUser });
        }

  

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedUser = await _userService.UpdateAsync(dto);
            if (updatedUser == null)
                return NotFound(new { Message = "User not found or update failed." });

            return Ok(new { Message = "User updated successfully.", User = updatedUser });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var success = await _userService.DeleteAsync(id);
            if (!success)
                return NotFound(new { Message = "User not found or delete failed." });

            return Ok(new { Message = "User deleted successfully." });
        }
        [HttpGet("roles")]
        public IActionResult GetRoles()
        {
            var roles = new[] { "SuperAdmin", "Admin", "HR", "Accounts", "Operations" };
            return Ok(roles);
        }
        
       
        }
    }

