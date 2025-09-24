using Haui.infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.infrastructure.UnitOFwork
{
    public interface IUnitOFwork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        Task<int> SaveChangeAssynt();

        IImageFileRepository ImageFile { get; }
    }
}
