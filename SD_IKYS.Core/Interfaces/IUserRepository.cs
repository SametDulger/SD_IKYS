using SD_IKYS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Core.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetByRoleAsync(int roleId);
        Task<bool> UsernameExistsAsync(string username);
        Task<bool> EmailExistsAsync(string email);
    }
} 