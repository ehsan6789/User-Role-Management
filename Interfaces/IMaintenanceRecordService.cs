using AUTHDEMO1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AUTHDEMO1.Interfaces
{
    public interface IMaintenanceRecordService
    {
        Task<IEnumerable<MaintenanceRecordDto>> GetAllMaintenanceRecordsAsync();
        Task<MaintenanceRecordDto> GetMaintenanceRecordByIdAsync(int id);
        Task<MaintenanceRecordDto> CreateMaintenanceRecordAsync(MaintenanceRecordForCreationDto dto);
        Task<bool> UpdateMaintenanceRecordAsync(int id, MaintenanceRecordForUpdateDto dto);
        Task<bool> DeleteMaintenanceRecordAsync(int id);
    }
}
