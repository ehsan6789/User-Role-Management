using AUTHDEMO1.DTOs;
using AUTHDEMO1.Models;
using AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // ApplicationUser → UserViewModel (for user list)
        CreateMap<ApplicationUser, UserViewModel>()
            .ForMember(dest => dest.Fullname, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

        // ApplicationUser → UserDto (used in GetById and Create)
        CreateMap<ApplicationUser, UserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
            .ForMember(dest => dest.Role, opt => opt.Ignore()) // will assign manually
            .ForMember(dest => dest.Users, opt => opt.Ignore())
            .ForMember(dest => dest.TotalUsers, opt => opt.Ignore());

        // DTO to Entity
        CreateMap<CreateUserDto, ApplicationUser>();
        CreateMap<UpdateUserDto, ApplicationUser>();
    }
}
