namespace NotificationService.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string Content { get; set; }
        public DateTime SentDate { get; set; }
        public string? Status { get; set; }
        public ChannelType Channel { get; set; }
        public Guid NotificationTypeId { get; set; }


    }
}
