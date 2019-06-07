using MKDRI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace MKDRI.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration configuration;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AuthService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            this.configuration = configuration;
            this.httpContextAccessor = httpContextAccessor;
        }

        protected User _currentUser;

        public User CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    int.TryParse(httpContextAccessor.HttpContext.User.FindFirst("Id").Value, out int id);
                    DateTime.TryParse(httpContextAccessor.HttpContext.User.FindFirst("CreatedOn").Value, out DateTime createdOn);
                    _currentUser = new User
                    {
                        Id = id,
                        FirstName = httpContextAccessor.HttpContext.User.FindFirst("FirstName").Value,
                        LastName = httpContextAccessor.HttpContext.User.FindFirst("LastName").Value,
                        Email = httpContextAccessor.HttpContext.User.FindFirst("Email").Value,
                        CreatedOn = createdOn,
                        DeletedOn = null
                    };
                }
                return _currentUser;
            }
        }

        public string GetTokenForUser(User user)
        {
            var claims = new[]
            {
                  new Claim("Id", user.Id.ToString()),
                  new Claim("FirstName", user.FirstName),
                  new Claim("LastName", user.LastName),
                  new Claim("CreatedOn", user.CreatedOn.ToString()),
                  new Claim("Email", user.Email),
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("SecretKey").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration.GetSection("TokenIssuer").Value,
              configuration.GetSection("TokenIssuer").Value,
              claims,
              expires: DateTime.Now.AddDays(7),
              signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
