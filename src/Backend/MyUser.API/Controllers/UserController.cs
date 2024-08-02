using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyUser.Application.User;
using MyUser.Communication.User.Requests;

namespace MyUser.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        await _userService.CreateUser(request);
        return Ok();
    }
}
