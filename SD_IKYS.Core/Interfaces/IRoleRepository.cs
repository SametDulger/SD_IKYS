using SD_IKYS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Core.Interfaces
{
    public interface IRoleRepository : IGenericRepository<Role>
    {
        Task<Role?> GetByNameAsync(string name);
        Task<IEnumerable<Role>> GetActiveRolesAsync();
        Task<bool> NameExistsAsync(string name);
    }
} 