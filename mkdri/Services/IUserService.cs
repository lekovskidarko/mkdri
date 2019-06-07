using MKDRI.Dtos;
using MKDRI.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Services
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(int id);
        Task<bool> RegisterUserAsync(CreateUserRequest request);
        Task<string> LoginUserAsync(UserLoginRequest request);
        UserDto GetSelf();
    }
}
