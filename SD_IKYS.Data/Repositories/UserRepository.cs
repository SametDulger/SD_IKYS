using Microsoft.EntityFrameworkCore;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using SD_IKYS.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _dbSet
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbSet
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<User>> GetByRoleAsync(int roleId)
        {
            return await _dbSet
                .Include(u => u.Role)
                .Where(u => u.RoleId == roleId)
                .ToListAsync();
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _dbSet.AnyAsync(u => u.Username == username);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(u => u.Email == email);
        }
    }
} 