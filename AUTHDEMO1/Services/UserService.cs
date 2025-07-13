using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly IMapper _mapper;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(IUserRepository userRepo, IMapper mapper, UserManager<ApplicationUser> userManager)
    {
        _userRepo = userRepo;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<UserDto> GetAllAsync()
    {
        var users = await _userRepo.GetAllAsync();
        var userViewModels = new List<UserViewModel>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var viewModel = _mapper.Map<UserViewModel>(user);

            viewModel.Role = roles.FirstOrDefault(); // Take first role (if user has multiple)
            userViewModels.Add(viewModel);
        }

        return new UserDto
        {
            Users = userViewModels,
            TotalUsers = userViewModels.Count
        };
    }


    public async Task<UserDto> GetByIdAsync(string id)
    {
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null) return null;

        var userDto = _mapper.Map<UserDto>(user);

        // Remove role population
        return userDto;
    }

    public async Task<UserDto> CreateAsync(CreateUserDto model)
    {
        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"User creation failed: {errors}");
        }

        // Assign Role
        if (!string.IsNullOrWhiteSpace(model.Role))
        {
            var roleExists = await _userManager.IsInRoleAsync(user, model.Role);
            if (!roleExists)
            {
                await _userManager.AddToRoleAsync(user, model.Role);
            }
        }

        var userDto = _mapper.Map<UserDto>(user);
        return userDto;
    }


    public async Task<UserDto> UpdateAsync(UpdateUserDto model)
    {
        var user = await _userRepo.GetByIdAsync(model.Id);
        if (user == null)
            throw new Exception("User not found");

        _mapper.Map(model, user);

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));

        return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await _userRepo.DeleteAsync(id);
    }
}
