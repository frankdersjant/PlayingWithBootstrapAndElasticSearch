using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Domain.DomainModels.Persons
{
    public class Person
    {
        public int id { get; set; }

        public Person()
        {
            Skills = new List<SkillData>();
            BirthDate = DateTime.Now.AddYears(-20);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public bool LikesMusic { get; set; }

        public string EmailAddress { get; set; }

        [JsonIgnore]
        public virtual ICollection<SkillData> Skills
        {
            get;
            set;
        }
    }
}
