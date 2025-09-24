using Haui.Domain.Entities;
using Haui.infrastructure.Context;
using Haui.infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.infrastructure.Repositories.Implementations
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(HauiContext context) : base(context)
        {
        }
    }
}
