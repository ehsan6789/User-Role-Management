
using AUTHDEMO1.Data;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using Microsoft.EntityFrameworkCore;

namespace AUTHDEMO1.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Department> GetByNameAsync(string name)
        {
            return await _context.Departments
                .FirstOrDefaultAsync(d => d.Name.ToLower() == name.ToLower());
        }
    }
}