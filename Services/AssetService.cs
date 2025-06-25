using AUTHDEMO1.Data;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using AutoMapper;

public class AssetService : IAssetService
{
    private readonly IAssetRepository _repo;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public AssetService(IAssetRepository repo, IMapper mapper, AppDbContext context)
    {
        _repo = repo;
        _mapper = mapper;
        _context = context;
    }

    public async Task<IEnumerable<AssetDto>> GetAllAssetsAsync()
    {
        var assets = await _repo.GetAllAsync();
        return _mapper.Map<IEnumerable<AssetDto>>(assets);
    }

    public async Task<AssetDto> GetAssetByIdAsync(int id)
    {
        var asset = await _repo.GetByIdAsync(id);
        return _mapper.Map<AssetDto>(asset);
    }

    public async Task AddAssetAsync(CreateAssetDto dto)
    {
        if (!string.IsNullOrWhiteSpace(dto.SerialNumber))
        {
            var exists = await _repo.SerialNumberExistsAsync(dto.SerialNumber);
            if (exists)
            {
                throw new InvalidOperationException("Serial number already exists.");
            }
        }

        var asset = _mapper.Map<Asset>(dto);
        await _repo.AddAsync(asset);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAssetAsync(UpdateAssetDto dto)
    {
        var asset = await _repo.GetByIdAsync(dto.Id);
        if (asset == null) throw new Exception("Asset not found");

        _mapper.Map(dto, asset);
        _repo.Update(asset);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAssetAsync(int id)
    {
        var asset = await _repo.GetByIdAsync(id);
        if (asset == null) throw new Exception("Asset not found");

        _repo.Delete(asset);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> SerialNumberExistsAsync(string serialNumber)
    {
        return await _repo.SerialNumberExistsAsync(serialNumber);
    }

}
