using AUTHDEMO1.Data;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AUTHDEMO1.Repositories
{
    public class AssetAssignmentRepository : IAssetAssignmentRepository
    {
        private readonly AppDbContext _context;

        public AssetAssignmentRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<AssetAssignment>> GetAllAsync() =>
            await _context.AssetAssignments
                         .Include(a => a.Asset)
                        
                         .ToListAsync();

        public async Task<AssetAssignment> GetByIdAsync(int id) =>
            await _context.AssetAssignments
                         .Include(a => a.Asset)
                         
                         .FirstOrDefaultAsync(x => x.Id == id);

        public async Task CreateAsync(AssetAssignment item)
        {
            try
            {
                _context.AssetAssignments.Add(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("DB Update Exception: " + ex.InnerException?.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Exception: " + ex.Message);
                throw;
            }
        }

        public async Task UpdateAsync(AssetAssignment item)
        {
            try
            {
                _context.AssetAssignments.Update(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("DB Update Exception (Update): " + ex.InnerException?.Message);
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item == null)
                throw new Exception("Asset assignment not found");

            try
            {
                _context.AssetAssignments.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("DB Update Exception (Delete): " + ex.InnerException?.Message);
                throw;
            }
        }
    }
}
