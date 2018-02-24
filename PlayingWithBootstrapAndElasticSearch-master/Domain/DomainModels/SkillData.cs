using Domain.DomainModels.Persons;

namespace Domain.DomainModels
{
    public class SkillData
    {
        public int Id { get; set; }
        public string Skill { get; set; }

        public int PersonId { get; set; }

        public virtual Person person { get; set; }

        public SkillData()
        {

        }

        public SkillData(string skill)
        {
            Skill = skill;
        }
    }
}
