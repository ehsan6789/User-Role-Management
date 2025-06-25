using AUTHDEMO1.DTOs;
using AUTHDEMO1.Interfaces;
using AUTHDEMO1.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);
            user.Role = roles.FirstOrDefault(); // Custom property on ApplicationUser
        }

        var userViewModels = _mapper.Map<List<UserViewModel>>(users);

        return new UserDto
        {
            Users = userViewModels,
            TotalUsers = userViewModels.Count,
        };
    }

    public async Task<UserDto> GetByIdAsync(string id)
    {
        var user = await _userRepo.GetByIdAsync(id);
        if (user == null) return null;

        var userDto = _mapper.Map<UserDto>(user);
        var roles = await _userManager.GetRolesAsync(user);
        userDto.Role = roles.FirstOrDefault();

        return userDto;
    }

    [HttpPost]
    public async Task<UserDto> CreateAsync(CreateUserDto model)
    {
        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName,
            IsActive = true
        };

        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));
            throw new Exception($"User creation failed: {errors}");
        }

        await _userManager.AddToRoleAsync(user, model.Role);

        var userDto = _mapper.Map<UserDto>(user);
        var roles = await _userManager.GetRolesAsync(user);
        userDto.Role = roles.FirstOrDefault();

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

        var existingRoles = await _userManager.GetRolesAsync(user);
        if (!existingRoles.Contains(model.Role))
        {
            await _userManager.RemoveFromRolesAsync(user, existingRoles);
            await _userManager.AddToRoleAsync(user, model.Role);
        }

        return _mapper.Map<UserDto>(user);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await _userRepo.DeleteAsync(id);
    }
}
