using AutoMapper;
using AUTHDEMO1.DTOs;
using AUTHDEMO1.Models;

namespace AUTHDEMO1.Helpers 
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // --- ApplicationUser Mappings ---
            CreateMap<CreateUserDto, ApplicationUser>();
            CreateMap<UpdateUserDto, ApplicationUser>();
            CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<ApplicationUser, UserDto>();

            CreateMap<ApplicationUser, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Role, opt => opt.Ignore())
                .ForMember(dest => dest.Users, opt => opt.Ignore())
                .ForMember(dest => dest.TotalUsers, opt => opt.Ignore());

            CreateMap<CreateUserDto, ApplicationUser>();
            CreateMap<UpdateUserDto, ApplicationUser>();

            // --- Department Mappings ---
            CreateMap<Department, DepartmentDto>().ReverseMap();

            // --- BankAccount Mappings ---
            CreateMap<BankAccount, BankAccountDto>().ReverseMap();
            CreateMap<CreateBankAccountDto, BankAccount>();

            // --- Employee Mappings ---
            CreateMap<Employee, EmployeeDto>()
         .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
         .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : "No Department"));
             //.ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.ApplicationUserId));

            CreateMap<CreateEmployeeDto, Employee>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<EmployeeStatus>(src.Status)));

            CreateMap<UpdateEmployeeDto, Employee>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => Enum.Parse<EmployeeStatus>(src.Status)));
            CreateMap<BankAccount, BankAccountDto>().ReverseMap();



            // --- Attendance Mappings ---
            CreateMap<Attendance, AttendanceDto>()
     .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            // --- LeaveRequest Mappings ---
            CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestDto>()
       .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))
       .ForMember(dest => dest.AnnualLeaveBalance, opt => opt.MapFrom(src => src.Employee.AnnualLeaveBalance))
       .ForMember(dest => dest.SickLeaveBalance, opt => opt.MapFrom(src => src.Employee.SickLeaveBalance))
       .ForMember(dest => dest.CasualLeaveBalance, opt => opt.MapFrom(src => src.Employee.CasualLeaveBalance));


            // --- Asset Mappings ---
            CreateMap<Asset, AssetDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

            CreateMap<CreateAssetDto, Asset>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<UpdateAssetDto, Asset>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ReverseMap();

            // --- Category Mappings ---
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();

            // --- Asset Assignment Mappings ---
            CreateMap<AssetAssignment, AssetAssignmentDto>()
               .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset.Name))
               .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))
               .ForMember(dest => dest.SerialNumber, opt => opt.MapFrom(src => src.Asset.SerialNumber)); 

            CreateMap<AssignAssetDto, AssetAssignment>();
            CreateMap<UpdateAssetAssignmentDto, AssetAssignment>();

            // --- Maintenance Record Mappings ---
            CreateMap<MaintenanceRecord, MaintenanceRecordDto>()
                .ForMember(dest => dest.AssetName, opt => opt.MapFrom(src => src.Asset.Name))
                .ForMember(dest => dest.AssetId, opt => opt.MapFrom(src => src.AssetId));
            CreateMap<CreateMaintenanceRecordDto, MaintenanceRecord>();
            CreateMap<UpdateMaintenanceRecordDto, MaintenanceRecord>();
        }
    }
}


