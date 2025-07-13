using AUTHDEMO1.Models;

public interface IUserRepository
{
    Task<List<ApplicationUser>> GetAllAsync();
    Task<ApplicationUser> GetByIdAsync(string id);
    Task<bool> CreateAsync(ApplicationUser user, string password, string role);
    Task<bool> UpdateAsync(ApplicationUser user);
    Task<bool> DeleteAsync(string id);
}
