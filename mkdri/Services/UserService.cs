using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;
using MKDRI.Dtos;
using MKDRI.Dtos.Requests;
using MKDRI.Models;
using MKDRI.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using MKDRI.Services.Auth;

namespace MKDRI.Services
{
    public class userService : IUserService
    {
        UnitOfWork unitOfWork;
        IAuthService authService;

        public userService(UnitOfWork unitOfWork, IAuthService authService)
        {
            this.authService = authService;
            this.unitOfWork = unitOfWork;
        }


        public async Task<UserDto> GetByIdAsync(int id)
        {
            UserDto user = await (from dbUsers in unitOfWork.Users
                                        where dbUsers.DeletedOn == null && dbUsers.Id == id
                                        select new UserDto
                                        {
                                            Id = dbUsers.Id,
                                            FirstName = dbUsers.FirstName,
                                            LastName = dbUsers.LastName,
                                        }).SingleOrDefaultAsync();
            if(user == default(UserDto))
            {
                throw new RequestError(404, "No matching user!");
            }
            return user;
        }

        public async Task<string> LoginUserAsync(UserLoginRequest request)
        {
            User user = await unitOfWork.Users.Where(x => x.Email == request.Email).SingleOrDefaultAsync();
            if(user == default(User))
            {
                throw new RequestError("No user registered with email.");
            }
            if(BCryptHelper.CheckPassword(request.Password, user.Password)){
                string token = authService.GetTokenForUser(user);
                return token;
            }
            else
            {
                throw new RequestError("Wrong password");
            }
        }

        public async Task<bool> RegisterUserAsync(CreateUserRequest request)
        {
            if (request.FirstName.Length == 0)
            {
                throw new RequestError("First name can not be empty");
            }
            if (request.FirstName.Length > 50)
            {
                throw new RequestError("First Name can not be longer than 50");
            }
            if (request.LastName.Length == 0)
            {
                throw new RequestError("Last name can not be empty");
            }
            if (request.LastName.Length > 50)
            {
                throw new RequestError("Last Name can not be longer than 50");
            }
            if (request.Email.Length == 0)
            {
                throw new RequestError("Email can not be empty");
            }
            if (request.Email.Length > 50)
            {
                throw new RequestError("Email can not be longer than 250");
            }
            bool exists = await (from dbUser in unitOfWork.Users where dbUser.Email == request.Email select dbUser.Id).CountAsync() > 0;
            if(exists)
            {
                throw new RequestError("Email already taken!");
            }
            if (!Regex.Match(request.Email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$").Success)
            {
                throw new RequestError("Email can not be longer than 250");
            }
            if (request.Password.Length < 8)
            {
                throw new RequestError("Password can not be shorter than 8 characters");
            }
            if (request.Password.Length > 50)
            {
                throw new RequestError("Password can not be longer than 25 characters");
            }
            bool hasNumber = new Regex(@"[0-9]+").IsMatch(request.Password);
            bool hasUpperChar = new Regex(@"[A-Z]+").IsMatch(request.Password);
            bool hasLowerChar = new Regex(@"[a-z]+").IsMatch(request.Password);
            bool hasSpecialChar = new Regex(@"[^\da - zA - Z]+").IsMatch(request.Password);
            if (!hasNumber)
            {
                throw new RequestError("Password must contain at least one digit");
            }
            if (!hasUpperChar)
            {
                throw new RequestError("Password must contain at least one upper case letter");
            }
            if (!hasLowerChar)
            {
                throw new RequestError("Password must contain at least one lower case letter");
            }
            if (!hasSpecialChar)
            {
                throw new RequestError("Password must contain at least one special character");
            }
            User user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = BCryptHelper.HashPassword(request.Password, BCryptHelper.GenerateSalt(12)),
                CreatedOn = DateTime.Now
            };
            unitOfWork.Users.Add(user);
            await unitOfWork.SaveAsync();
            return true;
        }

        public UserDto GetSelf()
        {
            User user = authService.CurrentUser;
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }
    }
}
