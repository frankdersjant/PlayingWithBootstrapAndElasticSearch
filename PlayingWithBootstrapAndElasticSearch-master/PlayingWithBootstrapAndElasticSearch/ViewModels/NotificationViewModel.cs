
using Domain.DomainModels.Notification;
using System.ComponentModel.DataAnnotations;
namespace PlayingWithBootstrap.ViewModels
{
    public class NotificationViewModel
    {
        public int id { get; set; }
        public int Count { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Remarks { get; set; }

        public NotificationTypes NotificationType { get; set; }

        public string BadgeClass { get; set; }
        public string UserId { get; set; }




    }
}