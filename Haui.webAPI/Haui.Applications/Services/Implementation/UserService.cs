using AutoMapper;
using Haui.Application.Dtos.BaseDto;
using Haui.Applications.Dtos;
using Haui.Applications.Services.Interfaces;
using Haui.Domain.Entities;
using Haui.infrastructure.UnitOFwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Haui.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOFwork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOFwork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddUserAsync(User user)
        {
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangeAssynt();
        }

        public async Task DeleteUserAsync(Guid Id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(Id);
            if (user != null) {
                await _unitOfWork.Users.Delete(user);
                await _unitOfWork.SaveChangeAssynt();
            }
        }
        
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _unitOfWork.Users.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid Id)
        {
            return await _unitOfWork.Users.GetByIdAsync(Id);
        }

        public async Task<PageResultDto<UserDto>> GetUserPageAsync(int page, int pageSize)
        {
            var query = _unitOfWork.Users.GetAllForPaging()
                .Include(u => u.Role)
                .Include(u => u.userSkills).ThenInclude(us => us.Skill);
            var totalItem = query.Count();
            var user = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PageResultDto<UserDto>
            {
                Page = page,
                PageSize = pageSize,
                TotalItem = totalItem,
                Items = _mapper.Map<List<UserDto>>(user)
            };
        }

        public async Task UpdateUserAsync(User user)
        {
            await _unitOfWork.Users.UpdateAsync(user);
            await _unitOfWork.SaveChangeAssynt();
        }
    }
}
