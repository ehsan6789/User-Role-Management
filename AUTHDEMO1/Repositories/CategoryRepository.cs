using AUTHDEMO1.Data;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using Microsoft.EntityFrameworkCore;

namespace AUTHDEMO1.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Category>> GetAllAsync() =>
            await _context.Categories.ToListAsync();

        public async Task<Category> GetByIdAsync(int id) =>
            await _context.Categories.FindAsync(id);

        public async Task CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            _context.Categories.Remove(item);
            await _context.SaveChangesAsync();
        }

        // ✅ New method for dropdown
        public async Task<List<string>> GetCategoryNamesAsync()
        {
            return await _context.Categories
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }
       
    }
}

