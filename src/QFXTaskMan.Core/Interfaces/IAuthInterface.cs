using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces;

public interface IAuthService
{
    string Authenticate(string email, string password);
    User Register(User user, string password);
}