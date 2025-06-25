using AUTHDEMO1.Models;

namespace AUTHDEMO1.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task CreateAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
        
        Task<List<string>> GetCategoryNamesAsync();

    }
}

