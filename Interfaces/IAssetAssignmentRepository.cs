using System.Collections.Generic;
using System.Threading.Tasks;
using AUTHDEMO1.Models;

namespace AUTHDEMO1.Interfaces
{
    public interface IAssetAssignmentRepository
    {
        Task<IEnumerable<AssetAssignment>> GetAllAsync();
        Task<AssetAssignment> GetByIdAsync(int id);
        Task CreateAsync(AssetAssignment entity);
        Task UpdateAsync(AssetAssignment entity);
        Task DeleteAsync(int id);
    }
}
