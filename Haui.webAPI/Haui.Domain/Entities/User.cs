using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public List<UserSkill> userSkills { get; set; } = new List<UserSkill>();
    }

}
