using System.Collections.Generic;
using System.Threading.Tasks;
using AUTHDEMO1.DTOs;

namespace AUTHDEMO1.Interfaces
{
    public interface IAssetAssignmentService
    {
        Task<IEnumerable<AssetAssignmentDto>> GetAllAssignmentsAsync();
        Task<AssetAssignmentDto> GetAssignmentByIdAsync(int id);
        Task<AssetAssignmentDto> AssignAssetAsync(AssignAssetDto dto);
        Task<AssetAssignmentDto> UpdateAssignmentAsync(int id, UpdateAssetAssignmentDto dto);
        Task DeleteAssignmentAsync(int id);
    }
}
