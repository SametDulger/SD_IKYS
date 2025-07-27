using SD_IKYS.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Business.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto?> GetByIdAsync(int id);
        Task<RoleDto> CreateAsync(CreateRoleDto createRoleDto);
        Task<RoleDto> UpdateAsync(int id, UpdateRoleDto updateRoleDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> NameExistsAsync(string name);
    }
} 