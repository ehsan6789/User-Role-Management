using AUTHDEMO1.Data;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using Microsoft.EntityFrameworkCore;
public class AssetRepository : IAssetRepository
{
    private readonly AppDbContext _context;

    public AssetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Asset>> GetAllAsync()
        => await _context.Assets.Include(a => a.Category).ToListAsync();

    public async Task<Asset> GetByIdAsync(int id)
        => await _context.Assets.Include(a => a.Category).FirstOrDefaultAsync(a => a.Id == id);

    public async Task AddAsync(Asset asset)
        => await _context.Assets.AddAsync(asset);

    public void Update(Asset asset)
        => _context.Assets.Update(asset);

    public void Delete(Asset asset)
        => _context.Assets.Remove(asset);
    public async Task<bool> SerialNumberExistsAsync(string serialNumber)
    {
        return await _context.Assets.AnyAsync(a => a.SerialNumber == serialNumber);
    }
}
