using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.Domain.Entities
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public List<UserSkill> userSkills { get; set; }= new List<UserSkill>();
    }
}
