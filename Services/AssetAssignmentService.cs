using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using AutoMapper;

namespace AUTHDEMO1.Services
{
    public class AssetAssignmentService : IAssetAssignmentService
    {
        private readonly IAssetAssignmentRepository _repository;
        private readonly IMapper _mapper;

        public AssetAssignmentService(IAssetAssignmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssetAssignmentDto>> GetAllAssignmentsAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AssetAssignmentDto>>(items);
        }

        public async Task<AssetAssignmentDto> GetAssignmentByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item == null ? null : _mapper.Map<AssetAssignmentDto>(item);
        }

        public async Task<AssetAssignmentDto> AssignAssetAsync(AssignAssetDto dto)
        {
            var item = _mapper.Map<AssetAssignment>(dto);
            await _repository.CreateAsync(item);
            return _mapper.Map<AssetAssignmentDto>(item);
        }

        public async Task<AssetAssignmentDto> UpdateAssignmentAsync(int id, UpdateAssetAssignmentDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Asset assignment not found");

            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);

            return _mapper.Map<AssetAssignmentDto>(existing);
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Asset assignment not found");

            await _repository.DeleteAsync(id);  // Pass id, not entity
        }

    }
}
