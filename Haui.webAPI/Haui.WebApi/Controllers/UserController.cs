using AutoMapper;
using Haui.Applications.Dtos;
using Haui.Applications.Services.Interfaces;
using Haui.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Haui.webAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        [Authorize]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> GetUserByIdAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            var userDto = _mapper.Map<UserDto>(user);
            return Ok(userDto);
        }
        [HttpPost]

        public async Task<ActionResult> CreateUser(UserDto userDto)
        {
            userDto.Id = Guid.NewGuid();
            var user = _mapper.Map<User>(userDto);
            await _userService.AddUserAsync(user);
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult> GetAllUser()
        {
            var users = await _userService.GetAllUserAsync();
            var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDtos);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserDto userDto) 
        {
           /* if(id != userDto.Id)
            {
                return BadRequest();
            }*/
            var user = await _userService.GetUserByIdAsync(userDto.Id);
            if(user == null)
            {
                return BadRequest();
            }
            var userUpdate = _mapper.Map<User>(userDto);
            await _userService.UpdateUserAsync(userUpdate);
            return NoContent();
        }
        [HttpDelete("{id}")]      
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return BadRequest();
            }

            await _userService.DeleteUserAsync(id);
            return Ok();
        }
        [HttpGet("user_pageds")]
        public async Task<ActionResult> GetAllPage([FromQuery]int page = 1,[FromQuery] int pageSize = 10)
        {
            var users = await _userService.GetUserPageAsync(page, pageSize);
            return Ok(users);
        }
    }
}

