using MKDRI.Models;

namespace MKDRI.Services.Auth
{
    public interface IAuthService
    {
        User CurrentUser { get; }
        string GetTokenForUser(User user);
    }
}