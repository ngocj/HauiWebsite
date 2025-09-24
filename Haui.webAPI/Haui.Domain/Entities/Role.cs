using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
