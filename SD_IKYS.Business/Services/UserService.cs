using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SD_IKYS.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return users.Select(MapToDto);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            return user != null ? MapToDto(user) : null;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto createUserDto)
        {
            if (await _unitOfWork.Users.UsernameExistsAsync(createUserDto.Username))
                throw new InvalidOperationException("Username already exists");

            if (await _unitOfWork.Users.EmailExistsAsync(createUserDto.Email))
                throw new InvalidOperationException("Email already exists");

            var user = new User
            {
                Username = createUserDto.Username,
                Email = createUserDto.Email,
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                PhoneNumber = createUserDto.PhoneNumber,
                RoleId = createUserDto.RoleId,
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };
            user.Password = _passwordHasher.HashPassword(user, createUserDto.Password);

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(user);
        }

        public async Task<UserDto> UpdateAsync(int id, UpdateUserDto updateUserDto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                throw new InvalidOperationException("User not found");

            if (updateUserDto.Username != user.Username && await _unitOfWork.Users.UsernameExistsAsync(updateUserDto.Username))
                throw new InvalidOperationException("Username already exists");

            if (updateUserDto.Email != user.Email && await _unitOfWork.Users.EmailExistsAsync(updateUserDto.Email))
                throw new InvalidOperationException("Email already exists");

            user.Username = updateUserDto.Username;
            user.Email = updateUserDto.Email;
            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;
            user.PhoneNumber = updateUserDto.PhoneNumber;
            user.RoleId = updateUserDto.RoleId;
            user.IsActive = updateUserDto.IsActive;
            user.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
                return false;

            await _unitOfWork.Users.DeleteAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<UserDto?> AuthenticateAsync(LoginDto loginDto)
        {
            var user = await _unitOfWork.Users.GetByUsernameAsync(loginDto.Username);
            if (user == null || _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password) != PasswordVerificationResult.Success || !user.IsActive)
                return null;

            return MapToDto(user);
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _unitOfWork.Users.UsernameExistsAsync(username);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _unitOfWork.Users.EmailExistsAsync(email);
        }

        private UserDto MapToDto(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                RoleId = user.RoleId,
                RoleName = user.Role?.Name ?? string.Empty,
                IsActive = user.IsActive
            };
        }
    }
} 