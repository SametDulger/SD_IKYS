using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SD_IKYS.Business.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _unitOfWork.Roles.GetAllAsync();
            return roles.Select(MapToDto);
        }

        public async Task<RoleDto?> GetByIdAsync(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);
            return role != null ? MapToDto(role) : null;
        }

        public async Task<RoleDto> CreateAsync(CreateRoleDto createRoleDto)
        {
            if (await _unitOfWork.Roles.NameExistsAsync(createRoleDto.Name))
                throw new InvalidOperationException("Bu rol adı zaten mevcut");

            var role = new Role
            {
                Name = createRoleDto.Name,
                Description = createRoleDto.Description,
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

            await _unitOfWork.Roles.AddAsync(role);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(role);
        }

        public async Task<RoleDto> UpdateAsync(int id, UpdateRoleDto updateRoleDto)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);
            if (role == null)
                throw new InvalidOperationException("Rol bulunamadı");

            if (updateRoleDto.Name != role.Name && await _unitOfWork.Roles.NameExistsAsync(updateRoleDto.Name))
                throw new InvalidOperationException("Bu rol adı zaten mevcut");

            role.Name = updateRoleDto.Name;
            role.Description = updateRoleDto.Description;
            role.IsActive = updateRoleDto.IsActive;
            role.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.Roles.UpdateAsync(role);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(role);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);
            if (role == null)
                return false;

            await _unitOfWork.Roles.DeleteAsync(role);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> NameExistsAsync(string name)
        {
            return await _unitOfWork.Roles.NameExistsAsync(name);
        }

        private RoleDto MapToDto(Role role)
        {
            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                IsActive = role.IsActive,
                CreatedDate = role.CreatedDate,
                UpdatedDate = role.UpdatedDate
            };
        }
    }
} 