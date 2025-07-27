using Microsoft.EntityFrameworkCore;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using SD_IKYS.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Data.Repositories
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Role?> GetByNameAsync(string name)
        {
            return await _dbSet
                .FirstOrDefaultAsync(r => r.Name == name);
        }

        public async Task<IEnumerable<Role>> GetActiveRolesAsync()
        {
            return await _dbSet
                .Where(r => r.IsActive)
                .ToListAsync();
        }

        public async Task<bool> NameExistsAsync(string name)
        {
            return await _dbSet.AnyAsync(r => r.Name == name);
        }
    }
} 