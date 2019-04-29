using MKDRI.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKDRI.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
    }
}
