using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace DataLayer
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity _identity;
        private readonly NotificationContext _context;

        private ApplicationUser _user;

        public CurrentUser(IIdentity identity, NotificationContext context)
        {
            _identity = identity;
            _context = context;
        }

        public ApplicationUser User
        {
            get { return _user ?? (_user = _context.Users.Find(_identity.GetUserId())); }
        }
    }
}
