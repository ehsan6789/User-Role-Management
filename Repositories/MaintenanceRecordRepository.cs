using AUTHDEMO1.Data;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using Microsoft.EntityFrameworkCore;

namespace AUTHDEMO1.Repositories
{
    public class MaintenanceRecordRepository : IMaintenanceRecordRepository
    {
        private readonly AppDbContext _context;

        public MaintenanceRecordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MaintenanceRecord>> GetAllAsync()
        {
            return await _context.MaintenanceRecords.Include(m => m.Asset).ToListAsync();
        }

        public async Task<MaintenanceRecord?> GetByIdAsync(int id)
        {
            return await _context.MaintenanceRecords.Include(m => m.Asset).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddAsync(MaintenanceRecord record)
        {
            await _context.MaintenanceRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MaintenanceRecord record)
        {
            _context.MaintenanceRecords.Update(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(MaintenanceRecord record)
        {
            _context.MaintenanceRecords.Remove(record);
            await _context.SaveChangesAsync();
        }
    }
}
