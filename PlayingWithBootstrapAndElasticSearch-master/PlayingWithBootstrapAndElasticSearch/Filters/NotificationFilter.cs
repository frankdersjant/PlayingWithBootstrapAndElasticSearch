using DataLayer;
using Domain.DomainModels.Notification;
using PlayingWithBootstrap.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PlayingWithBootstrap.Filters
{
    public class NotificationFilter : ActionFilterAttribute
    {
        public NotificationContext context { get; set; }
        public ICurrentUser user { get; set; }
        private IQueryable<NotificationViewModel> vm { get; set; } 
 
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = from n in context.Notifications where (n.UserId == user.User.Id) select n;

            if (result != null)
            {
                vm = result.GroupBy(n => n.NotificationType).Select(g => new NotificationViewModel
                                {
                                    Count = g.Count(),
                                    NotificationType = g.Key,
                                    BadgeClass = NotificationTypes.Email == g.Key
                                    ? "succes"
                                    : "info"
                                });
            }
            filterContext.Controller.ViewBag.Notices = vm;
        }
    }
}