using Microsoft.AspNetCore.Mvc;

namespace Customers.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUsersService _usersService;

    // Useful for unit testing and controlling instantiation of user controller
    public UserController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IActionResult> Get()
    {
        var users = await _usersService.GetAllUsers();

        // Only return Ok with status code 200 if some data
        if (users.Any()) 
        {
            return Ok(users);
        }
        return NotFound();
    }
}
