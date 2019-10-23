namespace MicroServices.Notification.Domain.Entities
{
    public class Notification
    {
        public string[] To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
