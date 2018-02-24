using AutoMapper;
using DataLayer;
using Domain.DomainModels.Notification;
using Microsoft.Web.Mvc;
using PlayingWithBootstrap.Filters;
using PlayingWithBootstrap.Models.BaseController;
using PlayingWithBootstrap.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PlayingWithBootstrap.Controllers
{
    [Authorize]
    public class NotificationController : BaseController
    {
        private NotificationContext _context { get; set; }
        private ICurrentUser _currentuser { get; set; }

        public NotificationController(NotificationContext context, ICurrentUser currentuser)
        {
            _context = context;
            _currentuser = currentuser;
        }

        [NotificationFilter]
        public ActionResult Index()
        {
            var loggedInUser = (from n in _context.Users
                                where (n.Id == _currentuser.User.Id)
                                select n).ToList();

            var result = Mapper.Map<List<ApplicationUser>, List<UserViewModel>>(loggedInUser);

            return View(result);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(NotificationViewModel notificationViewModel)
        {
            if (ModelState.IsValid)
            {
                Notification newNotification = new Notification(notificationViewModel.Title, notificationViewModel.NotificationType,
                                                                notificationViewModel.Remarks, notificationViewModel.UserId = _currentuser.User.Id);

                _context.Notifications.Add(newNotification);
                _context.SaveChanges();
                Success("Notification Added", true);
            }

            return this.RedirectToAction<NotificationController>(i => i.Index());
        }


    }
}