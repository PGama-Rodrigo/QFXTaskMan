using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces;

public interface IAuthService
{
    string Authenticate(string username, string password);
    User Register(User user, string password);
}