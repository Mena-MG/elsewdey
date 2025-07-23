using Microsoft.AspNetCore.Mvc;
using RegisterAPII.DTOs;
using RegisterAPII.Interfaces;
using System.Security.Claims;

namespace RegisterAPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationDto notificationDto)
        {
            try
            {
                var fromAccountId = GetCurrentUserId();
                var result = await _notificationService.CreateNotificationAsync(notificationDto, fromAccountId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}/mark-read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            try
            {
                var accountId = GetCurrentUserId();
                var result = await _notificationService.MarkAsReadAsync(id, accountId);
                
                if (!result)
                    return NotFound(new { message = "Notification not found" });
                
                return Ok(new { message = "Notification marked as read" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("my-notifications")]
        public async Task<IActionResult> GetMyNotifications()
        {
            var accountId = GetCurrentUserId();
            var notifications = await _notificationService.GetNotificationsByAccountIdAsync(accountId);
            return Ok(notifications);
        }

        [HttpGet("unread")]
        public async Task<IActionResult> GetUnreadNotifications()
        {
            var accountId = GetCurrentUserId();
            var notifications = await _notificationService.GetUnreadNotificationsByAccountIdAsync(accountId);
            return Ok(notifications);
        }

        [HttpGet("unread-count")]
        public async Task<IActionResult> GetUnreadCount()
        {
            var accountId = GetCurrentUserId();
            var count = await _notificationService.GetUnreadCountAsync(accountId);
            return Ok(new { count });
        }

        private int GetCurrentUserId()
        {
            // In a real application, extract from JWT token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }
            
            // Placeholder - in production, this should throw an exception or handle authentication properly
            return 1; // Default to first user for testing
        }
    }
}