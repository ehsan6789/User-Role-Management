using AUTHDEMO1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AUTHDEMO1.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetDto>> GetAllAssetsAsync();
        Task<AssetDto> GetAssetByIdAsync(int id);
        Task<AssetDto> CreateAssetAsync(AssetForCreationDto dto);
        Task<bool> UpdateAssetAsync(int id, AssetForUpdateDto dto);
        Task<bool> DeleteAssetAsync(int id);
        Task<bool> SerialNumberExistsAsync(string serialNumber);
    }
}
