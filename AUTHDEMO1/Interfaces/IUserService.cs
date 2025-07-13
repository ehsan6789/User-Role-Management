using AUTHDEMO1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using AUTHDEMO1.DTOs;
using System.Threading.Tasks;

namespace AUTHDEMO1.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetAllAsync();                      // List wrapper
        Task<UserDto> GetByIdAsync(string id);            // Get user by ID
        Task<UserDto> CreateAsync(CreateUserDto dto);     // Create user
        Task<UserDto> UpdateAsync(UpdateUserDto dto);     // Update user and return updated data
        Task<bool> DeleteAsync(string id);                // Delete
    }
}

