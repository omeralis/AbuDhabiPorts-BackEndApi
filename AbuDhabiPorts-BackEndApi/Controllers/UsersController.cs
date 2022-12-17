using AbuDhabiPorts_BackEndApi.Interfaces;
using AbuDhabiPorts_BackEndApi.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbuDhabiPorts_BackEndApi.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserInterface _userRepository;

    public UsersController(IUserInterface userInterface)
    {
        _userRepository = userInterface;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginViewModel userLoginModel)
    {
        var token = await _userRepository.Login(userLoginModel);
        return Ok(new {token});   
    }
}