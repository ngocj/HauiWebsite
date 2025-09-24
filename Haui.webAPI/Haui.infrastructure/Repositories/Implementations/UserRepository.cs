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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HauiContext context) : base(context)
        {
        }

        public IQueryable<User> GetAllForPaging()
        {
            return _context.Set<User>();
        }
    }
}
