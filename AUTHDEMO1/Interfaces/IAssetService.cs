using AUTHDEMO1.DTOs;

namespace AUTHDEMO1.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetDto>> GetAllAssetsAsync();
        Task<AssetDto> GetAssetByIdAsync(int id);
        Task AddAssetAsync(CreateAssetDto dto);
        Task UpdateAssetAsync(UpdateAssetDto dto);
        Task DeleteAssetAsync(int id);
        Task<bool> SerialNumberExistsAsync(string serialNumber);
    }
}
