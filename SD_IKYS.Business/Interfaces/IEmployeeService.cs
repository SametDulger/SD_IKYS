using SD_IKYS.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SD_IKYS.Business.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetByIdAsync(int id);
        Task<EmployeeDto> CreateAsync(CreateEmployeeDto createEmployeeDto);
        Task<EmployeeDto> UpdateAsync(int id, UpdateEmployeeDto updateEmployeeDto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetByDepartmentAsync(string department);
        Task<IEnumerable<EmployeeDto>> GetByManagerAsync(int managerId);
        Task<bool> TCKNExistsAsync(string tckn);
        Task<IEnumerable<EmployeeDto>> GetActiveEmployeesAsync();
        Task<bool> EmailExistsAsync(string email);
        Task<IEnumerable<EmployeeDto>> SearchAsync(string searchTerm);
    }
} 