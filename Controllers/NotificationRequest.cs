using Microsoft.AspNetCore.Mvc;
using NotificationService.Models;

namespace NotificationService.Controllers
{
    public class NotificationRequest
    {
        public Guid userId { get; set; }
        public Guid notificationId { get; set; }
        public ChannelType channel { get; set; }
        public string content { get; set; }
    }
}
