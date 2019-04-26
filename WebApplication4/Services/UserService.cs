using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            List<UserDto> users = (from dbUsers in unitOfWork.Users.All()
                                   where dbUsers.DeletedOn == null
                                    select new UserDto
                                    {
                                        Id = dbUsers.Id,
                                        FirstName = dbUsers.FirstName,
                                        LastName = dbUsers.LastName,
                                        CreatedOn = dbUsers.CreatedOn,
                                        DeletedOn = dbUsers.DeletedOn
                                    }).ToList();

            int id = 5;
            Laboratory lab = (from dbLabs in unitOfWork.Laboratories.All()
                              where dbLabs.Id == id
                              select dbLabs).SingleOrDefault();
            return users;
        }
    }
}
