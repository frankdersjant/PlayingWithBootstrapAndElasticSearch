using Domain.DomainModels.Notification;
using Domain.DomainModels.Persons;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace DataLayer
{
    public class NotificationContext : IdentityDbContext<ApplicationUser>
    {

        public NotificationContext()
            : base("PWB", throwIfV1Schema: false)
        {

        }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().Property(d => d.BirthDate).HasColumnType("datetime2");
            modelBuilder.HasDefaultSchema("PWB");

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
