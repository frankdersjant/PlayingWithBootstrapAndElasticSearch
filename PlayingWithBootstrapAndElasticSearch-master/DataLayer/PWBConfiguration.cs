using Domain.DomainModels;
using Domain.DomainModels.Notification;
using Domain.DomainModels.Persons;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayer
{
    public class PWBConfiguration : DropCreateDatabaseIfModelChanges<NotificationContext>
    {
        protected override void Seed(NotificationContext context)
        {
            CreateInitialContext(context);
        }

        public void CreateInitialContext(NotificationContext context)
        {

            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var user1 = new ApplicationUser() { Email = "f.dersjant@quicknet.nl", UserName = "f.dersjant@quicknet.nl", LikesMusic = true, BirthDate = DateTime.Now.AddYears(-50) };

            manager.Create(user1, "TestPass123!");

            List<Notification> notices = new List<Notification>();
            List<Person> persons = new List<Person>();

            Notification n = new Notification
            {
                Title = "John Smith was added to the system.",
                NotificationType = NotificationTypes.Registration,
                UserId = user1.Id,
                Remarks = "Remarks 1"
            };

            Notification n2 = new Notification
            {
                Title = "Susan Peters was added to the system.",
                NotificationType = NotificationTypes.Email,
                UserId = user1.Id,
                Remarks = "Remarks 2"
            };

            Notification n3 = new Notification
            {
                Title = "Just an FYI on Thursday's meeting",
                NotificationType = NotificationTypes.Email,
                UserId = user1.Id,
                Remarks = "Remarks 3"
            };

            notices.Add(n);
            notices.Add(n2);
            notices.Add(n3);

            foreach (Notification notice in notices)
            {
                context.Notifications.Add(notice);
            }

            List<SkillData> Skills = new List<SkillData>();

            Person p = new Person
            {
                FirstName = "Frank",
                LastName = "Dersjant",
                LikesMusic = true,
                EmailAddress = "f.dersjant@quicknet.nl",
            };

            p.Skills.Add(new SkillData("Math"));
            p.Skills.Add(new SkillData("C#"));

            persons.Add(p);

            Person p2 = new Person
            {
                FirstName = "Yueming",
                LastName = "Li",
                LikesMusic = true,
                EmailAddress = "yueder@hotmail.com",

            };

            p2.Skills.Add(new SkillData("C#"));
            p2.Skills.Add(new SkillData("Math"));
            p2.Skills.Add(new SkillData("Elasticsearch"));

            persons.Add(p2);


            foreach (Person person in persons)
            {
                context.Persons.Add(person);
            }

            context.SaveChanges();
        }
    }

}
