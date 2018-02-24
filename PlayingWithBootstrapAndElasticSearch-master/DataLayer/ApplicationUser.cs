using Domain.DomainModels.Notification;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace DataLayer
{
    public class ApplicationUser : IdentityUser
    {
        public IList<Notification> Notifications { get; set; }
        public DateTime BirthDate { get; set; }
        public bool LikesMusic { get; set; }
    }
}
