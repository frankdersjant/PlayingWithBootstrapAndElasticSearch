
namespace Domain.DomainModels.Notification
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Title { get; set; }
        public NotificationTypes NotificationType { get; set; }
        public string Remarks { get; set; }

        //Should be ApplicationUser!!
        public string UserId { get; set; }

        public Notification()
        {

        }

        public Notification(string t, NotificationTypes notificationtype, string remarks, string id)
        {
            Title = t;
            NotificationType = notificationtype;
            Remarks = remarks;
            UserId = id;
        }
    }
}
