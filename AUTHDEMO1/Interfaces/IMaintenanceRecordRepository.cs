using AUTHDEMO1.Models;

namespace AUTHDEMO1.Interfaces
{
    public interface IMaintenanceRecordRepository
    {
        Task<IEnumerable<MaintenanceRecord>> GetAllAsync();
        Task<MaintenanceRecord?> GetByIdAsync(int id);
        Task AddAsync(MaintenanceRecord record);
        Task UpdateAsync(MaintenanceRecord record);
        Task DeleteAsync(MaintenanceRecord record);
    }
}
