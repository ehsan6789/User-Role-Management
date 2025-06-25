using AUTHDEMO1.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AUTHDEMO1.Interfaces
{
    public interface IMaintenanceRecordService
    {
        Task<IEnumerable<MaintenanceRecordDto>> GetAllMaintenanceRecordsAsync();
        Task<MaintenanceRecordDto> GetMaintenanceRecordByIdAsync(int id);
        Task<MaintenanceRecordDto> CreateMaintenanceRecordAsync(CreateMaintenanceRecordDto dto);
        Task<MaintenanceRecordDto> UpdateMaintenanceRecordAsync(int id, UpdateMaintenanceRecordDto dto);
        Task DeleteMaintenanceRecordAsync(int id);
    }
}
