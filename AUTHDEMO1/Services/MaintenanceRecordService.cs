using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AUTHDEMO1.Services
{
    public class MaintenanceRecordService : IMaintenanceRecordService
    {
        private readonly IMaintenanceRecordRepository _repository;
        private readonly IMapper _mapper;

        public MaintenanceRecordService(IMaintenanceRecordRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MaintenanceRecordDto>> GetAllMaintenanceRecordsAsync()
        {
            var items = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MaintenanceRecordDto>>(items);
        }

        public async Task<MaintenanceRecordDto> GetMaintenanceRecordByIdAsync(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return _mapper.Map<MaintenanceRecordDto>(item);
        }

        public async Task<MaintenanceRecordDto> CreateMaintenanceRecordAsync(CreateMaintenanceRecordDto dto)
        {
            var item = _mapper.Map<MaintenanceRecord>(dto);
            await _repository.AddAsync(item);
            return _mapper.Map<MaintenanceRecordDto>(item);
        }

        public async Task<MaintenanceRecordDto> UpdateMaintenanceRecordAsync(int id, UpdateMaintenanceRecordDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Maintenance record not found");

            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
            return _mapper.Map<MaintenanceRecordDto>(existing);
        }

        public async Task DeleteMaintenanceRecordAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
                throw new Exception("Maintenance record not found");

            await _repository.DeleteAsync(existing);
        }
    }
}
