using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces;

public interface IAuthService
{
    Task <string> Authenticate(string username, string password);
    Task <User> Register(User user, string password);
}