using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MKDRI.Dtos;
using MKDRI.Dtos.Requests;
using MKDRI.Services;

namespace MKDRI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("self")]
        [Authorize]
        public UserDto GetSelf()
        {
            return userService.GetSelf();
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<UserDto> GetByIdAsync([FromRoute]int id)
        {
            return await userService.GetByIdAsync(id);
        }

        [HttpPut("")]
        public async Task<bool> RegisterUserAsync([FromBody] CreateUserRequest request)
        {
            return await userService.RegisterUserAsync(request);
        }

        [AllowAnonymous]
        [HttpPost("")]
        public async Task<string> LoginUserAsync([FromBody] UserLoginRequest request)
        {
            return await userService.LoginUserAsync(request);
        }
    }
}
