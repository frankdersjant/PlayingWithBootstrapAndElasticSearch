
using Domain.DomainModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PlayingWithBootstrap.ViewModels
{
    public class PersonVM
    {
        public int id { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [UIHint("Boolean.cshtml")]
        [Display(Name = "Likes Music")]
        public bool LikesMusic { get; set; }

        public ICollection<SkillData> Skills
        {
            get;
            set;
        }
    }
}