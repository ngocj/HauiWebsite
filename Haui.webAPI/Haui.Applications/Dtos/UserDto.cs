using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.Applications.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public Guid RoleId { get; set; }

    }
}
