using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;

namespace SD_IKYS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Create(CreateEmployeeDto createEmployeeDto)
        {
            try
            {
                var employee = await _employeeService.CreateAsync(createEmployeeDto);
                return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> Update(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            try
            {
                var employee = await _employeeService.UpdateAsync(id, updateEmployeeDto);
                return Ok(employee);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("department/{department}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetByDepartment(string department)
        {
            var employees = await _employeeService.GetByDepartmentAsync(department);
            return Ok(employees);
        }

        [HttpGet("manager/{managerId}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetByManager(int managerId)
        {
            var employees = await _employeeService.GetByManagerAsync(managerId);
            return Ok(employees);
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetActive()
        {
            var employees = await _employeeService.GetActiveEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("check-tckn/{tckn}")]
        public async Task<ActionResult<bool>> CheckTCKN(string tckn)
        {
            var exists = await _employeeService.TCKNExistsAsync(tckn);
            return Ok(exists);
        }

        [HttpGet("check-email/{email}")]
        public async Task<ActionResult<bool>> CheckEmail(string email)
        {
            var exists = await _employeeService.EmailExistsAsync(email);
            return Ok(exists);
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> Search(string searchTerm)
        {
            var employees = await _employeeService.SearchAsync(searchTerm);
            return Ok(employees);
        }
    }
} 