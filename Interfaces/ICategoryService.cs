using AUTHDEMO1.DTOs;

namespace AUTHDEMO1.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto dto);
        Task<CategoryDto> UpdateCategoryAsync(int id, UpdateCategoryDto dto);  
        Task DeleteCategoryAsync(int id);
    
        Task<List<string>> GetCategoryNamesAsync();
    }
}
