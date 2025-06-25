using AUTHDEMO1.DTOs;
using AUTHDEMO1.Models;
using AutoMapper;

public class AssetMappingProfile : Profile
{
    public AssetMappingProfile()
    {
        // Assets
        CreateMap<Asset, AssetDto>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

        CreateMap<CreateAssetDto, Asset>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status)); 

        CreateMap<UpdateAssetDto, Asset>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))  
            .ReverseMap();

        // Categories
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();

        // Asset Assignments
        CreateMap<AssetAssignment, AssetAssignmentDto>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset.Name));
        CreateMap<AssignAssetDto, AssetAssignment>();
        CreateMap<UpdateAssetAssignmentDto, AssetAssignment>();

        // Maintenance Records
        CreateMap<MaintenanceRecord, MaintenanceRecordDto>()
            .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset.Name))
            .ForMember(dest => dest.AssetId, opt => opt.MapFrom(src => src.AssetId));
        CreateMap<CreateMaintenanceRecordDto, MaintenanceRecord>();
        CreateMap<UpdateMaintenanceRecordDto, MaintenanceRecord>();
    }
}

