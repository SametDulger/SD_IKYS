using Microsoft.EntityFrameworkCore;
using SD_IKYS.Core.Entities;
using SD_IKYS.Core.Interfaces;
using SD_IKYS.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SD_IKYS.Data.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Employee?> GetByTCKNAsync(string tckn)
        {
            return await _dbSet
                .Include(e => e.Manager)
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.TCKN == tckn);
        }

        public async Task<IEnumerable<Employee>> GetByDepartmentAsync(string department)
        {
            return await _dbSet
                .Include(e => e.Manager)
                .Include(e => e.User)
                .Where(e => e.Department == department)
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetByManagerAsync(int managerId)
        {
            return await _dbSet
                .Include(e => e.Manager)
                .Include(e => e.User)
                .Where(e => e.ManagerId == managerId)
                .ToListAsync();
        }

        public async Task<bool> TCKNExistsAsync(string tckn)
        {
            return await _dbSet.AnyAsync(e => e.TCKN == tckn);
        }

        public async Task<IEnumerable<Employee>> GetActiveEmployeesAsync()
        {
            return await _dbSet
                .Include(e => e.Manager)
                .Include(e => e.User)
                .Where(e => e.IsActive)
                .ToListAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbSet.AnyAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> SearchAsync(string searchTerm)
        {
            return await _dbSet
                .Include(e => e.Manager)
                .Include(e => e.User)
                .Where(e => e.FirstName.Contains(searchTerm) || e.LastName.Contains(searchTerm) || e.Email.Contains(searchTerm))
                .ToListAsync();
        }
    }
} 