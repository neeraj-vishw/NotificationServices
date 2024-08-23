using NotificationService.Contracts;
using NotificationService.Data;
using NotificationService.Models;

namespace NotificationService.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotificationContext _context;
        public NotificationService(NotificationContext context)
        {
            _context = context;
        }
        public async Task<Notification> SendNotification(Guid userId, Guid notificationTypeId, ChannelType channel, string content)
        {

            Notification notification = new Notification
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                NotificationTypeId = notificationTypeId,
                Channel = channel,
                Content = content,
                SentDate = DateTime.UtcNow,
                Status = "Sent"
            };
            await Task.CompletedTask;
            return notification;
        }
    }
}
