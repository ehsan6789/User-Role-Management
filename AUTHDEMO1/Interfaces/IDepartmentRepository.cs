using AUTHDEMO1.Models;

namespace AUTHDEMO1.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> GetByNameAsync(string name);
    }
}
