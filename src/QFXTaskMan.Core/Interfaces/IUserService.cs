using QFXTaskMan.Core.Models;

namespace QFXTaskMan.Core.Interfaces;

public interface IUserService
{
    Task<User> Login(string username, string password);
    Task<User> Register(User user);
}