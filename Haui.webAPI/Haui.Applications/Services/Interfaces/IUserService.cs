using Haui.Application.Dtos.BaseDto;
using Haui.Applications.Dtos;
using Haui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haui.Applications.Services.Interfaces
{
    public interface IUserService
    {
        Task<PageResultDto<UserDto>> GetUserPageAsync(int page, int pageSize);
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(Guid Id);
        Task AddUserAsync(User user);
        Task DeleteUserAsync(Guid Id);
        Task UpdateUserAsync(User user);

    }
}
