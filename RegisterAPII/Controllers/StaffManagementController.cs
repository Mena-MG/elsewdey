using Microsoft.AspNetCore.Mvc;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;

namespace RegisterAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffManagementController : ControllerBase
    {
        private readonly IStaffManagementService _staffManagementService;

        public StaffManagementController(IStaffManagementService staffManagementService)
        {
            _staffManagementService = staffManagementService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff([FromBody] CreateStaffDto createStaffDto)
        {
            try
            {
                // TODO: Add authorization check for IT role
                var result = await _staffManagementService.CreateStaffAsync(createStaffDto);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStaff(int id, [FromBody] UpdateStaffDto updateStaffDto)
        {
            try
            {
                // TODO: Add authorization check for IT role
                var result = await _staffManagementService.UpdateStaffAsync(id, updateStaffDto);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            try
            {
                // TODO: Add authorization check for IT role
                var result = await _staffManagementService.DeleteStaffAsync(id);
                
                if (!result)
                    return NotFound(new { message = "Staff member not found" });
                
                return Ok(new { message = "Staff member deactivated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var staff = await _staffManagementService.GetStaffByIdAsync(id);
            if (staff == null)
                return NotFound();

            return Ok(staff);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStaff()
        {
            var staff = await _staffManagementService.GetAllStaffAsync();
            return Ok(staff);
        }

        [HttpGet("role/{roleId}")]
        public async Task<IActionResult> GetStaffByRole(int roleId)
        {
            var staff = await _staffManagementService.GetStaffByRoleAsync(roleId);
            return Ok(staff);
        }

        [HttpPut("{id}/activate")]
        public async Task<IActionResult> ActivateStaff(int id)
        {
            try
            {
                // TODO: Add authorization check for IT role
                var result = await _staffManagementService.ActivateStaffAsync(id);
                
                if (!result)
                    return NotFound(new { message = "Staff member not found" });
                
                return Ok(new { message = "Staff member activated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/deactivate")]
        public async Task<IActionResult> DeactivateStaff(int id)
        {
            try
            {
                // TODO: Add authorization check for IT role
                var result = await _staffManagementService.DeactivateStaffAsync(id);
                
                if (!result)
                    return NotFound(new { message = "Staff member not found" });
                
                return Ok(new { message = "Staff member deactivated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}