using AUTHDEMO1.Models;

namespace AUTHDEMO1.Interfaces
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<bool> SerialNumberExistsAsync(string serialNumber);
        Task<Asset> GetByIdAsync(int id);
        Task AddAsync(Asset asset);
        void Update(Asset asset);
        void Delete(Asset asset);
    }
}
