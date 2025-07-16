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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return employees.Select(MapToDto);
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            return employee != null ? MapToDto(employee) : null;
        }

        public async Task<EmployeeDto> CreateAsync(CreateEmployeeDto createEmployeeDto)
        {
            if (await _unitOfWork.Employees.TCKNExistsAsync(createEmployeeDto.TCKN))
                throw new InvalidOperationException("TCKN already exists");

            var employee = new Employee
            {
                TCKN = createEmployeeDto.TCKN,
                FirstName = createEmployeeDto.FirstName,
                LastName = createEmployeeDto.LastName,
                MiddleName = createEmployeeDto.MiddleName,
                DateOfBirth = createEmployeeDto.DateOfBirth,
                PlaceOfBirth = createEmployeeDto.PlaceOfBirth,
                PhoneNumber = createEmployeeDto.PhoneNumber,
                Email = createEmployeeDto.Email,
                Address = createEmployeeDto.Address,
                HireDate = createEmployeeDto.HireDate,
                Position = createEmployeeDto.Position,
                Department = createEmployeeDto.Department,
                Salary = createEmployeeDto.Salary,
                ManagerId = createEmployeeDto.ManagerId,
                UserId = createEmployeeDto.UserId,
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(employee);
        }

        public async Task<EmployeeDto> UpdateAsync(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            if (updateEmployeeDto.TCKN != employee.TCKN && await _unitOfWork.Employees.TCKNExistsAsync(updateEmployeeDto.TCKN))
                throw new InvalidOperationException("TCKN already exists");

            employee.TCKN = updateEmployeeDto.TCKN;
            employee.FirstName = updateEmployeeDto.FirstName;
            employee.LastName = updateEmployeeDto.LastName;
            employee.MiddleName = updateEmployeeDto.MiddleName;
            employee.DateOfBirth = updateEmployeeDto.DateOfBirth;
            employee.PlaceOfBirth = updateEmployeeDto.PlaceOfBirth;
            employee.PhoneNumber = updateEmployeeDto.PhoneNumber;
            employee.Email = updateEmployeeDto.Email;
            employee.Address = updateEmployeeDto.Address;
            employee.HireDate = updateEmployeeDto.HireDate;
            employee.Position = updateEmployeeDto.Position;
            employee.Department = updateEmployeeDto.Department;
            employee.Salary = updateEmployeeDto.Salary;
            employee.ManagerId = updateEmployeeDto.ManagerId;
            employee.UserId = updateEmployeeDto.UserId;
            employee.IsActive = updateEmployeeDto.IsActive;
            employee.UpdatedDate = DateTime.UtcNow;

            await _unitOfWork.Employees.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return MapToDto(employee);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
                return false;

            await _unitOfWork.Employees.DeleteAsync(employee);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<EmployeeDto>> GetByDepartmentAsync(string department)
        {
            var employees = await _unitOfWork.Employees.GetByDepartmentAsync(department);
            return employees.Select(MapToDto);
        }

        public async Task<IEnumerable<EmployeeDto>> GetByManagerAsync(int managerId)
        {
            var employees = await _unitOfWork.Employees.GetByManagerAsync(managerId);
            return employees.Select(MapToDto);
        }

        public async Task<bool> TCKNExistsAsync(string tckn)
        {
            return await _unitOfWork.Employees.TCKNExistsAsync(tckn);
        }

        public async Task<IEnumerable<EmployeeDto>> GetActiveEmployeesAsync()
        {
            var employees = await _unitOfWork.Employees.GetActiveEmployeesAsync();
            return employees.Select(MapToDto);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _unitOfWork.Employees.EmailExistsAsync(email);
        }

        public async Task<IEnumerable<EmployeeDto>> SearchAsync(string searchTerm)
        {
            var employees = await _unitOfWork.Employees.SearchAsync(searchTerm);
            return employees.Select(MapToDto);
        }

        private EmployeeDto MapToDto(Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                TCKN = employee.TCKN,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                DateOfBirth = employee.DateOfBirth,
                PlaceOfBirth = employee.PlaceOfBirth,
                PhoneNumber = employee.PhoneNumber,
                Email = employee.Email,
                Address = employee.Address,
                HireDate = employee.HireDate,
                Position = employee.Position,
                Department = employee.Department,
                Salary = employee.Salary,
                ManagerId = employee.ManagerId,
                ManagerName = employee.Manager != null ? $"{employee.Manager.FirstName} {employee.Manager.LastName}" : null,
                UserId = employee.UserId,
                UserName = employee.User != null ? employee.User.Username : null,
                IsActive = employee.IsActive
            };
        }
    }
} 