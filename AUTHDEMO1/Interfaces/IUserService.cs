using AUTHDEMO1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using AUTHDEMO1.DTOs;
using System.Threading.Tasks;

namespace AUTHDEMO1.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetAllAsync();                     
        Task<UserDto> GetByIdAsync(string id);           
        Task<UserDto> CreateAsync(CreateUserDto dto);    
        Task<UserDto> UpdateAsync(UpdateUserDto dto);     
        Task<bool> DeleteAsync(string id);                
    }
}

