using Haui.infrastructure.Context;
using Haui.infrastructure.Repositories.Implementations;
using Haui.infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.infrastructure.UnitOFwork
{
    public class UnitWork : IUnitOFwork
    {
        protected readonly HauiContext _context;

        public UnitWork(HauiContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Roles = new RoleRepository(_context);
            ImageFile = new ImageFileRepository(_context);

        }
        public IUserRepository Users { get; }
        public IRoleRepository Roles { get; }  
        public IImageFileRepository ImageFile { get; }

        public void Dispose()
        {
            _context.Dispose();
        }      
        public async Task<int> SaveChangeAssynt()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
