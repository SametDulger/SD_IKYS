using Microsoft.AspNetCore.Mvc;
using SD_IKYS.Business.Interfaces;
using SD_IKYS.Core.DTOs;
using SD_IKYS.Core.Interfaces;

namespace SD_IKYS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleDto>>> GetAll()
        {
            var roles = await _unitOfWork.Roles.GetAllAsync();
            var roleDtos = roles.Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                IsActive = r.IsActive
            });
            return Ok(roleDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetById(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);
            if (role == null)
                return NotFound();

            var roleDto = new RoleDto
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                IsActive = role.IsActive
            };

            return Ok(roleDto);
        }

        [HttpPost]
        public async Task<ActionResult<RoleDto>> Create(CreateRoleDto createRoleDto)
        {
            try
            {
                if (await _unitOfWork.Roles.NameExistsAsync(createRoleDto.Name))
                    return BadRequest("Role name already exists");

                var role = new SD_IKYS.Core.Entities.Role
                {
                    Name = createRoleDto.Name,
                    Description = createRoleDto.Description,
                    CreatedDate = DateTime.UtcNow,
                    IsActive = true
                };

                await _unitOfWork.Roles.AddAsync(role);
                await _unitOfWork.SaveChangesAsync();

                var roleDto = new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description,
                    IsActive = role.IsActive
                };

                return CreatedAtAction(nameof(GetById), new { id = role.Id }, roleDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoleDto>> Update(int id, UpdateRoleDto updateRoleDto)
        {
            try
            {
                var role = await _unitOfWork.Roles.GetByIdAsync(id);
                if (role == null)
                    return NotFound();

                if (updateRoleDto.Name != role.Name && await _unitOfWork.Roles.NameExistsAsync(updateRoleDto.Name))
                    return BadRequest("Role name already exists");

                role.Name = updateRoleDto.Name;
                role.Description = updateRoleDto.Description;
                role.IsActive = updateRoleDto.IsActive;
                role.UpdatedDate = DateTime.UtcNow;

                await _unitOfWork.Roles.UpdateAsync(role);
                await _unitOfWork.SaveChangesAsync();

                var roleDto = new RoleDto
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description,
                    IsActive = role.IsActive
                };

                return Ok(roleDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var role = await _unitOfWork.Roles.GetByIdAsync(id);
            if (role == null)
                return NotFound();

            await _unitOfWork.Roles.DeleteAsync(role);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("check-name/{name}")]
        public async Task<ActionResult<bool>> CheckName(string name)
        {
            var exists = await _unitOfWork.Roles.NameExistsAsync(name);
            return Ok(exists);
        }
    }

    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class CreateRoleDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateRoleDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
} 