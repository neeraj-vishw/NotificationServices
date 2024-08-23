using NotificationService.Models;

namespace NotificationService.Contracts
{
    public interface INotificationService
    {
        Task<Notification> SendNotification(Guid userId, Guid notificationTypeId, ChannelType channel, string content);
    }
}
