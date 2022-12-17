using AbuDhabiPorts_BackEndApi.ViewModels.Users;

namespace AbuDhabiPorts_BackEndApi.Interfaces;

public interface IUserInterface
{
    Task<string> Login(UserLoginViewModel loginModel);
}
