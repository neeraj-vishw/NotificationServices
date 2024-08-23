using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationService.Data;
using NotifyService = NotificationService.Contracts.INotificationService;

namespace NotificationService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController: ControllerBase
    {
        private readonly NotificationContext _context;
        private readonly NotifyService _notificationService;
        public NotificationController(NotificationContext context, NotifyService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationRequest request)
        {
            var notification = await _notificationService.SendNotification(request.userId, request.notificationId, request.channel, request.content);
            return Ok(notification);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return NotFound();

            return Ok(notification);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var notifications = await _context.Notifications
                .Where(n => n.SentDate >= fromDate && n.SentDate <= toDate)
                .ToListAsync();

            return Ok(notifications);
        }
    }
}
