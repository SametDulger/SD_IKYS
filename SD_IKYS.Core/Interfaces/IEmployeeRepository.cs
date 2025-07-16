using SD_IKYS.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Core.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee?> GetByTCKNAsync(string tckn);
        Task<IEnumerable<Employee>> GetByDepartmentAsync(string department);
        Task<IEnumerable<Employee>> GetByManagerAsync(int managerId);
        Task<bool> TCKNExistsAsync(string tckn);
        Task<IEnumerable<Employee>> GetActiveEmployeesAsync();
        Task<bool> EmailExistsAsync(string email);
        Task<IEnumerable<Employee>> SearchAsync(string searchTerm);
    }
} 