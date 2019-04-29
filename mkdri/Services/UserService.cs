using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MKDRI.Dtos;
using MKDRI.Models;
using MKDRI.Repositories.UnitOfWork;

namespace MKDRI.Services
{
    public class UserService : IUserService
    {
        UnitOfWork unitOfWork;

        public UserService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            List<UserDto> users = (from dbUsers in unitOfWork.Users
                                   where dbUsers.DeletedOn == null
                                    select new UserDto
                                    {
                                        Id = dbUsers.Id,
                                        FirstName = dbUsers.FirstName,
                                        LastName = dbUsers.LastName,
                                        CreatedOn = dbUsers.CreatedOn,
                                        DeletedOn = dbUsers.DeletedOn
                                    }).ToList();

            return users;
        }
    }
}
